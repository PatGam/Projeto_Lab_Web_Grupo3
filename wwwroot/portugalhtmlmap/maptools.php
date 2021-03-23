<?php

$options = portugal_html5map_plugin_get_options();
$option_keys = is_array($options) ? array_keys($options) : array();
$map_id  = (isset($_REQUEST['map_id'])) ? intval($_REQUEST['map_id']) : array_shift($option_keys);

function portugal_html5map_plugin_detect_csv_header(&$row) {
    static $header = array(
        'states' => null,
        'groups' => null,
        'points' => null,
    );

    if (is_null($header['states'])) {
        foreach($header as $k => $v)
            $header[$k] = portugal_html5map_plugin_get_csv_import_export_keys($k);
    }

    if (count($row) < 5) return null;

    foreach($header as $type => $type_header_map) {
        $type_header = array_keys($type_header_map);
        if ($type_header[0] == $row[0] and $type_header[1] == $row[1] and $type_header[2] == $row[2]
            and $type_header[3] == $row[3] and $type_header[4] == $row[4])
            return $type;
    }

    return null;
}

function portugal_html5map_plugin_detect_click_action(&$params) {
    if (empty($params['clickAction'])) {
        if (!empty($params['link']))
            $params['clickAction'] = preg_match('/javascript:[\w_]+_set_state_text[^\(]*\([^\)]+\);/', $params['link']) ? 'info' : 'link';
        elseif (!empty($params['popup-id']) or !empty($params['popup_id']))
            $params['clickAction'] = 'popup';
        elseif (!empty($map_options['info'][$id]))
            $params['clickAction'] = 'info';
        else
            $params['clickAction'] = 'none';
    }
    switch ($params['clickAction']) {
        case 'info':
            $params['link'] = '#info';
            $params['isNewWindow'] = false;
            break;
        case 'popup':
            $params['link'] = '#popup';
            $params['isNewWindow'] = false;
            break;
        case 'link':
            break;
        case 'none':
            $params['link'] = '';
            break;
    }
}

function portugal_html5map_plugin_import_csv(&$errors) {
    $types = array('text/csv','text/comma-separated-values','application/vnd.ms-excel','application/csv','application/excel','application/vnd.msexcel','application/octet-stream');
    $json_types = array('application/json');
    $field_delimiters = array(
        ',' => ',',
        ';' => ';',
        ':' => ':',
        'sp'=> ' ',
        'tb'=> "\t"
    );
    $text_delimiters = array(
        "'" => "'",
        '"' => '"',
        'n' => null
    );
    $errors = array();

    if (! is_uploaded_file($_FILES['csv-file']['tmp_name']))
        $errors[] = __('File upload error!', 'portugal-html5-map');
    else {
        if (in_array($_FILES['csv-file']['type'], $json_types)) {
            $errors[] = sprintf(__('JSON import should be done on the "<a href="%s">Maps dashboard</a>" tab', 'portugal-html5-map'), "admin.php?page=portugal-html5-map-maps");
        }
        elseif (!in_array($_FILES['csv-file']['type'], $types)) {
            $errors[] = __('Wrong file type!', 'portugal-html5-map');
        }
    }
    $fd = stripslashes($_REQUEST['field-delimiter']);
    $td = stripslashes($_REQUEST['text-delimiter']);
    if ( ! array_key_exists($fd, $field_delimiters)) {
         $errors[] = __('Wrong field delimiter!', 'portugal-html5-map');
    }
    else {
        $fd = $field_delimiters[$fd];
    }
    if ( ! array_key_exists($td, $text_delimiters)) {
         $errors[] = __('Wrong text delimiter!', 'portugal-html5-map').$td;
    }
    else {
        $td = $text_delimiters[$td];
    }
    
    if ($errors)
        return false;
 
    $fh = fopen($_FILES['csv-file']['tmp_name'], 'r');
    $head = fgetcsv($fh, 0, $fd, $td);
    if ( ! $head) {
        $errors[] = __('Wrong csv file!', 'portugal-html5-map');
        return false;
    }
    if ( ! ($current_type = portugal_html5map_plugin_detect_csv_header($head))) {
        $errors[] = __('Wrong csv header!', 'portugal-html5-map');
        return false;
    }
    $data = array(
        'states' => array(),
        'groups' => array(),
        'points' => array(),
    );
    while ($line = fgetcsv($fh, 0, $fd, $td)) {
        if ($new_type = portugal_html5map_plugin_detect_csv_header($line)) {
            $current_type = $new_type;
            $head = $line;
            continue;
        }
        $data[$current_type][$line[0]] = array();
        foreach ($head as $i => $k)
            $data[$current_type][$line[0]][$k] = $line[$i];
    }
    fclose($fh);
    unlink($_FILES['csv-file']['tmp_name']);

    $all_options = portugal_html5map_plugin_get_options();
    $options_keys = array_keys($all_options);
    $def_map_id = reset($options_keys);

    $map_id = isset($_GET['map_id']) ? (int)$_GET['map_id'] : $def_map_id;
    $map_options = &$all_options[$map_id];

    if (!empty($data['states'])) {
        $import_export_keys = portugal_html5map_plugin_get_csv_import_export_keys('states');
        unset($import_export_keys['id'], $import_export_keys['info']);
        $fields = array_keys($import_export_keys);
        $new_fields = array_values($import_export_keys);
        $st_params = json_decode($map_options['map_data'], true);
        foreach ($st_params as $id => &$params) {
            if (!isset($data['states'][$id]))
                continue;
            if (isset($data['states'][$id]['info']))
                $map_options['state_info'][preg_replace('/\D+/', '', $id)] = $data['states'][$id]['info'];
            foreach ($fields as $i => $f) {
                $params[$new_fields[$i]] = isset($data['states'][$id][$f]) ? $data['states'][$id][$f] : '';
            }
            portugal_html5map_plugin_detect_click_action($params);
            unset($params['clickAction']);
            unset($data['states'][$id]);
            foreach (array('isNewWindow' ,'popup-id', 'group', '_hide_name', 'hidden', 'class') as $f) {
                if ($params[$f] === '') unset($params[$f]);
            }
        }
        unset($params);
        $st_params = json_encode($st_params, defined('JSON_UNESCAPED_UNICODE') ? JSON_UNESCAPED_UNICODE : null);
        if ($st_params)
            $map_options['map_data'] = $st_params;
        else
            $errors[] = __('Failed to encode new data! Probably non UTF data.', 'portugal-html5-map');

        if (count($data['states'])) {
            $errors[] = __('Some data left unimported! Looks like wrong map.', 'portugal-html5-map');
        }
    }
    if (!empty($data['groups'])) {
        $import_export_keys = portugal_html5map_plugin_get_csv_import_export_keys('groups');
        unset($import_export_keys['groupId']);
        $fields = array_keys($import_export_keys);
        $new_fields = array_values($import_export_keys);
        $map_options['groups'] = array();
        foreach ($data['groups'] as $id => $params) {
            if (!isset($map_options['groups'][$id]))
                $map_options['groups'][$id] = array();
            foreach ($fields as $i => $f) {
                $map_options['groups'][$id][$new_fields[$i]] = isset($data['groups'][$id][$f]) ? $data['groups'][$id][$f] : '';
            }
            portugal_html5map_plugin_detect_click_action($map_options['groups'][$id]);
            unset($map_options['groups'][$id]['clickAction']);
            unset($data['groups'][$id]);
            foreach (array('isNewWindow' ,'popup-id') as $f) {
                if ($map_options['groups'][$id][$f] === '') unset($map_options['groups'][$id][$f]);
            }
            foreach (array('_popup_over' ,'_act_over', '_clr_over', '_ignore_group') as $f) {
                $map_options['groups'][$id][$f] = in_array(strtolower($map_options['groups'][$id][$f]), array('yes', 'on', 'y'));
            }
        }
    }
    if (!empty($data['points'])) {
        $import_export_keys = portugal_html5map_plugin_get_csv_import_export_keys('points');
        unset($import_export_keys['pointId'], $import_export_keys['info']);
        $fields = array_keys($import_export_keys);
        $new_fields = array_values($import_export_keys);
        $map_options['points'] = array();
        foreach ($data['points'] as $id => $params) {
            if (!isset($map_options['points'][$id]))
                $map_options['points'][$id] = array();
            if (isset($data['points'][$id]['info']))
                $map_options['state_info'][$id] = $data['points'][$id]['info'];
            foreach ($fields as $i => $f) {
                $map_options['points'][$id][$new_fields[$i]] = isset($data['points'][$id][$f]) ? $data['points'][$id][$f] : '';
            }
            portugal_html5map_plugin_detect_click_action($map_options['points'][$id]);
            unset($map_options['points'][$id]['clickAction']);
            unset($data['points'][$id]);
            foreach (array('isNewWindow' ,'popup_id', 'color' ,'colorOver', 'borderColor', 'borderColorOver',
                'nameColor', 'nameColorOver', 'nameStrokeColor', 'nameStrokeColorOver', 'nameFontSize', 'class') as $f) {
                if ($map_options['points'][$id][$f] === '') unset($map_options['points'][$id][$f]);
            }
            $map_options['points'][$id]['x'] = (float)$map_options['points'][$id]['x'];
            $map_options['points'][$id]['y'] = (float)$map_options['points'][$id]['y'];
            $map_options['points'][$id]['tx'] = (float)$map_options['points'][$id]['tx'];
            $map_options['points'][$id]['ty'] = (float)$map_options['points'][$id]['ty'];
            if (isset($map_options['points'][$id]['nameFontSize']))
                $map_options['points'][$id]['nameFontSize'] = max(3, min(20, (int)$map_options['points'][$id]['nameFontSize']));
        }
    }
    if ($errors) {
        return false;
    }

    $map_options['update_time'] = time();
    portugal_html5map_plugin_save_options($all_options);
    return true;
}


if (isset($_POST['action']) && $_POST['action'] == 'portugal-html5-map-import-csv') {
    if (portugal_html5map_plugin_import_csv($errors))
        portugal_html5map_plugin_messages(array(__('Configuration successfully imported!', 'portugal-html5-map')), null);
    else
        portugal_html5map_plugin_messages(null, $errors);
} elseif (isset($_POST['action']) && $_POST['action'] == 'portugal-html5-map-save-js') {
    $map_options = &$options[$map_id];
    $map_options['customJs']   = stripslashes($_POST['custom_js']);
    $map_options['update_time'] = time();
    portugal_html5map_plugin_save_options($options);
    portugal_html5map_plugin_messages(array(__('Custom js successfully updated!', 'portugal-html5-map')), null);
}

echo "<div class=\"wrap portugal-html5-map main full\"><h2>" . __('Tools', 'portugal-html5-map') . "</h2>";
?>
<script>
jQuery(function(){

    jQuery('.portugal-html5-map-acs-label').click(function() {
        jQuery(this)
            .toggleClass('portugal-html5-map-closed')
            .next().filter('.portugal-html5-map-acs').toggleClass('portugal-html5-map-closed');
    });

    jQuery('.csv-import').click(function() {
        jQuery('input[name=csv-file]').click();
        return false;
    });

    jQuery('input[name=csv-file]').change(function() {
        var btn  = jQuery('.csv-import');
        var text = jQuery(btn).data('text') ? jQuery(btn).data('text') : jQuery(btn).text();

        jQuery(btn).data('text',text);

        jQuery('.csv-import').text(text + " (" + jQuery(this).val() + ")");
        if (this.checkValidity && !this.checkValidity())
            return;
        jQuery('form[name=action_form_import] input[name=action]').val('portugal-html5-map-import-csv');
        jQuery('form[name=action_form_import]').submit();
    });
});
</script>
<br>
<form method="POST" class="" name="action_form_import" enctype="multipart/form-data">
<?php 
    portugal_html5map_plugin_map_selector('tools', $map_id, $options);
    echo "<br /><br />\n";
    portugal_html5map_plugin_nav_tabs('tools', $map_id);
?>
    <h3><?php _e('Batch export / import from CSV', 'portugal-html5-map') ?></h3>
    <input type="submit" class="button button-secondary export" value="<?php esc_attr_e('Export to CSV file', 'portugal-html5-map'); ?>" />&nbsp;&nbsp;&nbsp;
    <input type="button" class="button button-secondary csv-import" value="<?php esc_attr_e('Import from CSV file', 'portugal-html5-map'); ?>" />
    <br/><br/>
    <label class="portugal-html5-map-acs-label portugal-html5-map-closed"><?php _e('Advanced CSV settings', 'portugal-html5-map'); ?></label>
    <div class="portugal-html5-map-acs  portugal-html5-map-closed" style="padding-bottom: 10px">
        <label class="title"><?php _e('Field delimiter:', 'portugal-html5-map') ?></label> <select name="field-delimiter" style="width: 100px">
            <option value=",">,</option>
            <option value=";">;</option>
            <option value=":">:</option>
            <option value="sp"><?php _e('{SPACE}', 'portugal-html5-map') ?></option>
            <option value="tb"><?php _e('{TAB}', 'portugal-html5-map') ?></option>
        </select><br>
        <label class="title"><?php _e('Text delimiter:', 'portugal-html5-map') ?></label> <select name="text-delimiter"  style="width: 100px">
            <option value='"'>"</option>
            <option value="'">'</option>
        </select>
        <input type="file" accept="text/csv,text/comma-separated-values" name="csv-file" style="display: none">
    </div>
    <br>
    <p><?php printf(__('Note that this tool exports/imports area data only. If you need to make a full backup of all settings of the map including general settings, use the backup option provided on <a href="%s">"Maps"</a> page.', 'portugal-html5-map'), '?page=portugal-html5-map-maps'); ?></p>
    <p class="help"><?php _e('* The term "area" means one of the following: continent, country, state, province, county or district, depending on the particular plugin.', 'portugal-html5-map'); ?></p>
    <input type="hidden" name="action" value="portugal-html5-map-export-csv">
    </form>

    <br><br>
    <form method="POST" class="" name="action_form_js" enctype="multipart/form-data">
    <h3><?php _e('Custom JavaScript', 'portugal-html5-map') ?></h3>
    <p><?php _e('Here you can add any custom javascript to extend plugin\'s functionality', 'portugal-html5-map') ?></p>
    <label class="portugal-html5-map-acs-label portugal-html5-map-closed"><?php _e('Detailed description', 'portugal-html5-map'); ?></label>
    <div class="portugal-html5-map-acs  portugal-html5-map-closed">
        <p><?php _e('Any code placed here will be executed after the map is drawn.', 'portugal-html5-map') ?></p>
        <p><?php _e('Here are the list of plugin-related variables, that will be available for you:', 'portugal-html5-map') ?><ul>
        <li><b>map</b> - <?php _e('Map instance. All available features are listed <a href="https://docs.html5maps.com/html5-locator-maps/api">here</a>.', 'portugal-html5-map') ?></li>
        <li><b>containerId</b> - <?php _e('HTML id of the container that contains the map.', 'portugal-html5-map') ?></li>
        <li><b>mapId</b> - <?php _e('Id of the map, specified in shortcode.', 'portugal-html5-map') ?></li>
        </ul>
        <p><?php _e('You can find out any id of the area or point by viewing the CSV export.', 'portugal-html5-map'); ?></p>
        <h4>Example:</h4>
        <pre class="code">
<span class="v">map</span>.<span class="m">on</span>(<span class="s">'click'</span>, <span class="k">function</span> (<span class="v">event</span>, <span class="v">sid</span>, <span class="v">map</span>) {
    <span class="k">var</span> <span class="v">name</span> = <span class="v">map</span>.<span class="m">fetchStateAttr</span>(<span class="v">sid</span>, <span class="s">'name'</span>);
    <span class="v">console</span>.<span class="m">log</span>(<span class="s">'Clicked state is: '</span> + <span class="v">name</span>);
});</pre>
    </div>
    <div style="clear: both"></div>
    <textarea name="custom_js" rows="20" style="width: 80%"><?php echo $options[$map_id]['customJs'] ? htmlspecialchars($options[$map_id]['customJs']) : '' ?></textarea>
    <input type="hidden" name="action" value="portugal-html5-map-save-js" />
    <p class="submit"><input type="submit" value="<?php esc_attr_e('Save Changes', 'portugal-html5-map'); ?>" class="button-primary" id="submit" name="submit"></p>
    </form>
</div>
