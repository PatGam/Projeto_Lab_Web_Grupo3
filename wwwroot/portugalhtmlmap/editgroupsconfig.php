<?php

$popups  = portugal_html5map_plugin_popup_builder_list_available_popups();
$MAP_COLOR_NORMAL = '#acacac';
$MAP_COLOR_BUSY   = '#898989';
$MAP_COLOR_ACTIVE = '#ff0000';
$MAP_COLOR_OVER   = '#fba2a2';

$options = portugal_html5map_plugin_get_options();
$option_keys = is_array($options) ? array_keys($options) : array();
$map_id  = (isset($_REQUEST['map_id'])) ? intval($_REQUEST['map_id']) : array_shift($option_keys);

$states  = $options[$map_id]['map_data'];
$states  = json_decode($states, true);

$group_id = (isset($_GET['g_id']) AND $_GET['g_id'] != '') ? intval($_GET['g_id']) : NULL;

$groups = isset($options[$map_id]['groups']) ? $options[$map_id]['groups'] : array();

$msgs_success = array();
$msgs_errors  = array();

if((isset($_POST['act_type']) AND $_POST['act_type'] == 'portugal-html5-map-groups-create')) {
    $name = sanitize_text_field($_POST['new_name']);
    if ( ! $name)
        $msgs_errors[] = __("No group name is specified", 'portugal-html5-map');
    else {
        foreach ($groups as $gr) {
            if ($gr['group_name'] == $name)
            $msgs_errors[] = sprintf(__("Group with name \"%s\" already exists", 'portugal-html5-map'), $name);
        }
    }
    if ( ! $msgs_errors) {
        $groups[] = portugal_html5map_plugin_group_defaults($name);
        $options[$map_id]['groups'] = $groups;
        portugal_html5map_plugin_save_options($options);
        ?>
        <script>
        document.location.href='<?php echo admin_url("admin.php?page=portugal-html5-map-groups&map_id=$map_id&g_id=".max(array_keys($groups))) ?>';
        </script>
        <?php
    }
}elseif((isset($_POST['act_type']) AND $_POST['act_type'] == 'portugal-html5-map-groups-save')) {

    if (isset($_POST['group_name']) AND ($gname = sanitize_text_field($_POST['group_name'])) AND $gname != $groups[$group_id]['group_name']) {
        foreach ($groups as $gr) {
            if ($gr['group_name'] == $gname)
            $msgs_errors[] = sprintf(__("Group with name \"%s\" already exists", 'portugal-html5-map'), $gname);
        }
        if ( ! $msgs_errors)
            $groups[$group_id]['group_name'] = $gname;
    }
    if ( ! $msgs_errors) {
        foreach ($states as &$st) {
            if (isset($st['group']) AND $st['group'] == $group_id)
                unset($st['group']);
        }
        unset($st);
        $sts = (isset($_POST['states']) AND $_POST['states']) ? explode(',', $_POST['states']) : array();
        foreach ($states as $sid => &$st) {
            if (in_array($sid, $sts))
                $st['group'] = $group_id;
        }
        unset($st);

        $groups[$group_id]['_act_over'] = (isset($_POST['_act_over']) AND $_POST['_act_over']) ? TRUE : NULL;
        $groups[$group_id]['_popup_over'] = (isset($_POST['_popup_over']) AND $_POST['_popup_over']) ? TRUE : NULL;
        $groups[$group_id]['_clr_over'] = (isset($_POST['_clr_over']) AND $_POST['_clr_over']) ? TRUE : NULL;
        $groups[$group_id]['_ignore_group'] = (isset($_POST['_ignore_group']) AND $_POST['_ignore_group']) ? TRUE : NULL;

        if (isset($_POST['name']))
            $groups[$group_id]['name'] = sanitize_text_field(stripcslashes($_POST['name']));
        if (isset($_POST['comment']))
            $groups[$group_id]['comment'] = wp_kses_post(stripcslashes($_POST['comment']));
        if (isset($_POST['image']))
            $groups[$group_id]['image'] = sanitize_text_field(stripcslashes($_POST['image']));

        if (isset($_POST['URL']))
            $groups[$group_id]['link'] = portugal_html5map_plugin_chk_url(stripcslashes($_POST['URL']));
        if (isset($_POST['info']))
            $groups[$group_id]['info'] = wp_kses_post(stripcslashes($_POST['info']));
        $groups[$group_id]['isNewWindow'] = isset($_POST['isNewWindow']) ? TRUE : FALSE;

        if (isset($_POST['color']))
            $groups[$group_id]['color_map'] = portugal_html5map_plugin_chk_color($_POST['color']);
        if (isset($_POST['color_over']))
            $groups[$group_id]['color_map_over'] = portugal_html5map_plugin_chk_color($_POST['color_over']);
        if (isset($_POST['popup-id']))
            $groups[$group_id]['popup-id'] = intval($_POST['popup-id']);
        $options[$map_id]['groups'] = $groups;
        $options[$map_id]['map_data'] = json_encode($states);
        $options[$map_id]['update_time'] = time();
        portugal_html5map_plugin_save_options($options);
        $msgs_success[] = __("Areas successfully assigned, settings saved", 'portugal-html5-map');
    }
}
elseif (isset($_GET['act_type']) AND 'portugal-html5-map-groups-delete' == $_GET['act_type']) {
    if ( ! wp_verify_nonce($_GET['_wpnonce'], "map_id=$map_id&g_id=$group_id"))
        wp_nonce_ays();
    if ($_SERVER['REQUEST_METHOD'] == 'POST') {
        check_admin_referer("map_id=$map_id&g_id=$group_id");
        foreach ($states as &$st) {
            if (isset($st['group']) AND $st['group'] == $group_id)
                unset($st['group']);
        }
        unset($st);
        unset($groups[$group_id]);
        $options[$map_id]['groups'] = $groups;
        $options[$map_id]['map_data'] = json_encode($states);
        $options[$map_id]['update_time'] = time();
        portugal_html5map_plugin_save_options($options);
        ?>
        <script>
        document.location.href='<?php echo admin_url("admin.php?page=portugal-html5-map-groups&map_id=$map_id") ?>';
        </script>
        <?php
        exit;
    } else {
    echo "<div class=\"wrap\"><h2>" . __('Portugal Map: delete group', 'portugal-html5-map') . "</h2>";
    ?>
    <p><?php echo sprintf(__('You are going to delete "%s" group from map "%s".', 'portugal-html5-map'), "<b>".$groups[$group_id]['group_name']."</b>", "<b>".$options[$map_id]['name']."</b>") ?></p>
    <p><?php _e('Are you sure you want to delete this group?', 'portugal-html5-map') ?></p>
    <form method="post" style="display: inline">
        <?php wp_nonce_field( "map_id=$map_id&g_id=$group_id" ) ?>
        <input type="submit" class="button" name="submit" value="<?php esc_attr_e('Yes, delete this group', 'portugal-html5-map') ?>" />
        <a class="button" href="?page=portugal-html5-map-groups&map_id=<?php echo $map_id ?>&g_id=<?php echo $group_id ?>"><?php _e('No, go back to selected group', 'portugal-html5-map') ?></a>
    </form>
    <?php
    exit;
    }
}



#########################################################################################

echo "<div class=\"wrap\"><h2>" . __('Configuration of groups', 'portugal-html5-map') . "</h2>";
portugal_html5map_plugin_messages($msgs_success, $msgs_errors);
?>
<script xmlns="http://www.w3.org/1999/html">
    jQuery(function($){
        $('.tipsy-q').tipsy({gravity: 'w'}).css('cursor', 'default');

        jQuery('.color~.colorpicker').each(function(){
            var me = this;

            jQuery(this).farbtastic(function(color){

                var textColor = this.hsl[2] > 0.5 ? '#000' : '#fff';

                jQuery(me).prev().prev().css({
                    background: color,
                    color: textColor
                }).val(color);

                if(jQuery(me).next().find('input').prop('checked')) {
                    return;
                    var dirClass = jQuery(me).prev().prev().hasClass('colorSimple') ? 'colorSimple' : 'colorOver';

                    jQuery('.'+dirClass).css({
                        background: color,
                        color: textColor
                    }).val(color);
                }

            });

            jQuery.farbtastic(this).setColor(jQuery(this).prev().prev().val());

            jQuery(jQuery(this).prev().prev()[0]).bind('change', function(){
                jQuery.farbtastic(me).setColor(this.value);
            });

            jQuery(this).hide();
            jQuery(this).prev().prev().bind('focus', function(){
                jQuery(this).next().next().fadeIn();
            });
            jQuery(this).prev().prev().bind('blur', function(){
                jQuery(this).next().next().fadeOut();
            });
        });

        $('select[name=group_select]').change(function() {
            location.href='admin.php?page=portugal-html5-map-groups&map_id=<?php echo $map_id ?>&g_id='+$(this).val();
        });

    });
</script>
<br />
<form method="POST" class="portugal-html5-map main" name="action_form">
<?php 
    portugal_html5map_plugin_map_selector('groups', $map_id, $options);
    echo "<br /><br />\n";
    portugal_html5map_plugin_nav_tabs('groups', $map_id);
?>

    <p><?php echo __('This tab allow you grouping several areas into groups with specific behavior. This way you can represent sales territories, reseller zones etc.', 'portugal-html5-map'); ?></p>
    <p class="help"><?php echo __('* The term "area" means one of the following: state, country, province, county or district, depending on the particular plugin.', 'portugal-html5-map'); ?></p>

    <fieldset>
        <legend><?php echo __('Group selection', 'portugal-html5-map'); ?></legend>
    <?php if ($groups) { ?>
    <select name="group_select" <?php if (!$groups) echo 'disabled="disabled"' ?>>
        <option value=""><?php echo __('Select a group', 'portugal-html5-map'); ?></option>
        <?php

        foreach($groups as $g_id => $vals)
        {
            ?>
            <option value="<?php echo $g_id ?>" <?php echo $group_id === $g_id ? ' selected' : ''?>><?php echo preg_replace('/^\s?<!--\s*?(.+?)\s*?-->\s?$/', '\1', $vals['group_name']); ?></option>
            <?php
        }
        ?>
        </select><span style="padding: 10px; font-weight: bold"><?php echo __('or', 'portugal-html5-map'); ?></span>
        <span><?php echo __('Create a new one:', 'portugal-html5-map'); ?></span>
<?php } else { ?>
        <span><?php echo __('Create a new group:', 'portugal-html5-map'); ?></span>
<?php } ?>
        <input type="text" name="new_name" value="<?php echo __('New group', 'portugal-html5-map'); ?>" />
        <input type="submit" class="button button-primary newgroup" value="<?php echo __('Add new group', 'portugal-html5-map'); ?>" />
    
    </fieldset>
    <input type="hidden" name="act_type" value="portugal-html5-map-groups-create" />
</form>
<form method="POST" class="portugal-html5-map main" name="action_form2">
<?php if (!is_null($group_id)) {
portugal_html5map_plugin_sort_regions_list($states, 'asc');
$doptions= portugal_html5map_plugin_map_defaults();
$dstates = json_decode($doptions['map_data'], true);
$selected = array();
foreach ($dstates as $sid => &$ds) {
    $ds['color_map'] = $MAP_COLOR_NORMAL;
    if (isset($states[$sid]['group']))
    {
        if ($states[$sid]['group'] == $group_id)
            $selected[] = $sid;
        else
        {
            $ds['color_map'] = $MAP_COLOR_BUSY;
            $ds['comment'] = sprintf(__('This area assigned to "%s" group', 'portugal-html5-map'), $groups[$states[$sid]['group']]['group_name']);
        }
    }
    $ds['color_map_over'] = $MAP_COLOR_OVER;
}
unset($ds);
$doptions['map_data'] = json_encode($dstates);

$vals        = $groups[$group_id];
$rad_nill    = "";
$rad_url     = "";
$rad_more    = "";
$rad_popup   = "";
$style_input = "";
$style_area  = "";
$style_popup = "";

$mce_options = array(
    //'media_buttons' => false,
    'editor_height'   => 150,
    'textarea_rows'   => 20,
    'textarea_name'   => 'info',
    'tinymce' => array(
        'add_unload_trigger' => false,
    )
);

if(trim($vals['link']) == "") $rad_nill = "checked";
elseif(stripos($vals['link'], "#popup") !== false ) $rad_popup = "checked";
elseif(stripos($vals['link'], "javascript:portugalhtml5map_set_state_text") !== false OR $vals['link'] == '#info') $rad_more = "checked";
else $rad_url = "checked";

if($rad_url != "checked") $style_input = "display: none;";
if($rad_more != "checked") $style_area = "display: none;";
if($rad_popup!="checked") $style_popup = "display: none;";

?>
    <fieldset class="states_selection">
        <legend><a style="box-shadow: none; -webkit-box-shadow: none" href="javascript:void(0)"><?php echo __('Area selection', 'portugal-html5-map'); ?> [<span style="font-family: mono"><?php echo $selected ? '+' : '-'; ?></span>]</a></legend>
        <div id="st_selected"></div>
        <div id="st_preview">
            <p style="display: none"><?php _e('Click to select areas you want to include to the group. If you click an area already assigned to another group, it will be re-assigned to this group instead.', 'portugal-html5-map'); ?></p>
            <hr>
            <label><?php echo __('Enable zoom:', 'portugal-html5-map') ?> <input type="checkbox" onchange="map.enableZoom(jQuery(this).prop('checked'), true)"></label>
            <hr>
            <div id="map_container"></div>
        </div>
    </fieldset>

    <fieldset class="group_settings">
        <legend><?php echo __('Group settings', 'portugal-html5-map'); ?></legend>

        <div style="" id="stateinfo" class="stateinfo">

        <div style="float: left; width: 50%;">
            <span class="title"><?php echo __('Group name:', 'portugal-html5-map'); ?> </span><input class="" type="text" name="group_name" value="<?php echo $vals['group_name']?>" />
            <span class="tipsy-q" original-title="<?php esc_attr_e('Name of this group', 'portugal-html5-map'); ?>">[?]</span>
        </div>
        <div style="float: left; width: 50%;">
            <label><input name="_ignore_group" type="checkbox" <?php if (!empty($vals['_ignore_group'])) echo 'checked="checked"' ?> /> <?php echo __('Keep individual highlighting', 'portugal-html5-map'); ?></label>
        </div>
        <div class="clear"></div>
<hr/><br/>
        <label><input name="_popup_over" type="checkbox" <?php if ($vals['_popup_over']) echo 'checked="checked"' ?> /> <?php echo __('Override individual tooltip settings', 'portugal-html5-map'); ?></label>
        <br/><br />
        <span class="title"><?php echo __('Displayed name:', 'portugal-html5-map'); ?> </span><input class="" type="text" name="name" value="<?php echo $vals['name']?>" />
        <span class="tipsy-q" original-title="<?php esc_attr_e('Display this name when mouse is over the group', 'portugal-html5-map'); ?>">[?]</span>
        <div class="clear"></div>
        <span class="title"><?php echo __('Info for tooltip balloon:', 'portugal-html5-map'); ?> <span class="tipsy-q" original-title="<?php esc_attr_e('Info for tooltip balloon', 'portugal-html5-map'); ?>">[?]</span> </span>
        <?php portugal_html5map_plugin_wp_editor_for_tooltip($vals['comment'], 'comment', 'comment'); ?>
        <br />
        <span class="title"><?php echo __('Image URL:', 'portugal-html5-map'); ?> </span>
            <input onclick="imageFieldId = this.id; tb_show('Image', 'media-upload.php?type=image&tab=library&TB_iframe=true');" class="" type="text" id="image" name="image" value="<?php echo $vals['image']?>" />
            <span style="font-size: 10px; cursor: pointer;" onclick="clearImage(this)"><?php echo __('clear', 'portugal-html5-map'); ?></span>
        <span class="tipsy-q" original-title="<?php esc_attr_e('The path to file of the image to display in a popup', 'portugal-html5-map'); ?>">[?]</span><br />
<br/><hr/><br/>



        <label><input name="_act_over" type="checkbox" <?php if ($vals['_act_over']) echo 'checked="checked"' ?> /> <?php echo __('Override individual action settings', 'portugal-html5-map'); ?></label>
        <br/><br />
        <span class="title"><?php echo __('What to do when the group is clicked:', 'portugal-html5-map'); ?></span>
        <label><input type="radio" name="URLswitch" id="n" value="nill" <?php echo $rad_nill?> autocomplete="off">&nbsp;<?php echo __('Nothing', 'portugal-html5-map'); ?></label> <span class="tipsy-q" original-title="<?php esc_attr_e('Do not react on mouse clicks', 'portugal-html5-map'); ?>">[?]</span>
        <label><input type="radio" name="URLswitch" id="u" value="url" <?php echo $rad_url?> autocomplete="off">&nbsp;<?php echo __('Open a URL', 'portugal-html5-map'); ?></label> <span class="tipsy-q" original-title="<?php esc_attr_e('A click on this group opens a specified URL', 'portugal-html5-map'); ?>">[?]</span>
        <label><input type="radio" name="URLswitch" id="m" value="more" <?php echo $rad_more?> autocomplete="off">&nbsp;<?php echo __('Show more info', 'portugal-html5-map'); ?></label> <span class="tipsy-q" original-title="<?php esc_attr_e('Displays a side-panel with additional information (contacts, addresses etc.)', 'portugal-html5-map'); ?>">[?]</span>
        <label><input type="radio" name="URLswitch" id="p" value="popup-builder" <?php echo $rad_popup?> autocomplete="off" <?php echo (!count($popups)) ? "disabled" : ""; ?>>&nbsp;<?php echo __('Show lightbox popup', 'portugal-html5-map'); ?></label> <span class="tipsy-q" original-title="<?php esc_attr_e('Show lightbox popup, that you are can create with the plugin "Popup Builder"', 'portugal-html5-map'); ?>">[?]</span><br />
        <div style="<?php echo $style_input; ?>" id="stateURL">
            <span class="title"><?php echo __('URL:', 'portugal-html5-map'); ?> </span><input style="width: 240px;" class="" type="text" name="URL" id="URL" value="<?php echo $vals['link']?>" />
            <span class="tipsy-q" original-title="<?php esc_attr_e('The landing page URL', 'portugal-html5-map'); ?>">[?]</span>&nbsp;&nbsp;&nbsp;
            <label><input type="checkbox" name="isNewWindow" <?php if (!empty($vals['isNewWindow'])) echo 'checked="checked" '; ?>/> <?php echo __('Open url in a new window', 'portugal-html5-map'); ?></label></br>
        </div>
        <div style="<?php echo $style_area; ?>" id="stateDescr"><br />
            <span class="title"><?php echo __('Description:', 'portugal-html5-map'); ?> <span class="tipsy-q" original-title="<?php esc_attr_e('The description is displayed to the right of the map and contains contacts or some other additional information', 'portugal-html5-map'); ?>">[?]</span> </span>
            <?php wp_editor($vals['info'], 'info', $mce_options); ?>
            </br>
        </div>

        <div style="<?php echo $style_popup; ?>" id="statePopup"><br />
            <span class="title"><?php echo __('Select lightbox popup:', 'portugal-html5-map'); ?> </span>
            <select name="popup-id">
                <?php foreach($popups as $pId => $pTitle) { ?>
                <option value="<?php echo $pId; ?>" <?php echo (isset($vals['popup-id']) AND $vals['popup-id']==$pId) ? "selected" : ""; ?>><?php echo $pTitle; ?></option>
                <?php } ?>
            </select>
        </div>
<br/><hr><br/>


        <label><input name="_clr_over" type="checkbox" <?php if ($vals['_clr_over']) echo 'checked="checked"' ?> /> <?php echo __('Override individual color settings', 'portugal-html5-map'); ?></label>
        <br/><br/>
        <span class="title"><?php echo __('Group color:', 'portugal-html5-map'); ?> </span><input class="color colorSimple" type="text" name="color" value="<?php echo $vals['color_map']?>" style="background-color: #<?php echo $vals['color_map']?>"  />
        <span class="tipsy-q" original-title='<?php esc_attr_e('The color of a group.', 'portugal-html5-map'); ?>'>[?]</span><div class="colorpicker"></div>
        <br />
        <span class="title"><?php echo __('Group hover color:', 'portugal-html5-map'); ?> </span><input class="color colorOver" type="text" name="color_over" value="<?php echo $vals['color_map_over']?>" style="background-color: #<?php echo $vals['color_map_over']?>"  />
        <span class="tipsy-q" original-title='<?php echo __('The color of a group when the mouse cursor is over it.', 'portugal-html5-map'); ?>'>[?]</span><div class="colorpicker"></div>
        <br />
    </fieldset>
    <link rel='stylesheet' href='<?php echo portugal_html5map_plugin_get_static_url('css/map.css') ?>'>
    <script type='text/javascript' src='<?php echo portugal_html5map_plugin_get_raphael_js_url() ?>'></script>
    <script type='text/javascript' src='<?php echo portugal_html5map_plugin_get_map_js_url($options[$map_id]) ?>'></script>
    <style>
        <?php echo portugal_html5map_plugin_prepare_tooltip_css($options[$map_id], '#st_preview') ?>
    </style>
<?php
$mapCfg = array(
    'mapWidth'      => 0,
    'mapHeight'     => 0,

    'shadowAllow'   => false,

    'zoomMax'       => (isset($options[$map_id]['zoomMax']) AND $options[$map_id]['zoomMax']) ? $options[$map_id]['zoomMax'] : $doptions['zoomMax'],
    'zoomStep'      => (isset($options[$map_id]['zoomStep']) AND $options[$map_id]['zoomStep']) ? $options[$map_id]['zoomStep'] : $doptions['zoomStep'],

    'iPhoneLink'    => $doptions['iPhoneLink'] === 'false' ? false : (!!$doptions['iPhoneLink']),
    'isNewWindow'   => $doptions['isNewWindow'] === 'false' ? false : (!!$doptions['isNewWindow']),

    'borderColor'       => $doptions['borderColor'],
    'borderColorOver'   => $doptions['borderColorOver'],

    'nameColor'         => $doptions['nameColor'],
    'nameFontSize'      => $options[$map_id]['nameFontSize'] . 'px',
    'nameFontFamily'    => portugal_html5map_plugin_escape_fonts($options[$map_id]['nameFontFamily'], 'Arial, sans-serif'),
    'nameFontWeight'    => $options[$map_id]['nameFontWeight'],

    'overDelay'         => $doptions['overDelay'],
    'nameStroke'        => $doptions['nameStroke'] ? true : false,
    'nameStrokeColor'   => $doptions['nameStrokeColor'],
    'map_data'          => json_decode($doptions['map_data'], 1)
);
?>
    <script>
        var imageFieldId = false;
        var map_cfg = <?php echo json_encode($mapCfg) ?>;
<?php
    if (file_exists($params_file = dirname(__FILE__).'/static/paths.json')) {
        echo "map_cfg.map_params = ".file_get_contents($params_file).";\n";
    }
?>
        var map = new FlaShopPortugalMap(map_cfg);
        var prev  = jQuery('#st_preview');
        var slctd = jQuery('#st_selected');
        function getSelectedNames() {
            var res = [];
            var keys = Object.keys(map.selectedStates);
            for (var i = 0; i < keys.length; i++) {
                keys[i] = keys[i].replace(map.id(), '');
                res.push(map.fetchStateAttr(keys[i], 'name'));
            }
            return res.join(', ');
        }
        jQuery(function($){
            map.draw('map_container');
<?php if ($selected) { ?>
            prev.hide();
            var selected = <?php echo json_encode($selected); ?>;
            for (var i = 0; i < selected.length; i++)
                map.stateHighlightOn(selected[i], '<?php echo $MAP_COLOR_ACTIVE ?>');
            slctd.html(getSelectedNames());
<?php } ?>
            prev.find('p').show();
            map.on('click', function(ev, sid) {
                if (map.selectedStates[map.id()+sid])
                    map.stateHighlightOff(sid);
                else
                    map.stateHighlightOn(sid, '<?php echo $MAP_COLOR_ACTIVE ?>');
            });
            $('input.savegroup').click(function() {
                $('input[name=act_type]').val('portugal-html5-map-groups-save');
                var keys = Object.keys(map.selectedStates);
                for (var i = 0; i < keys.length; i++) {
                    keys[i] = keys[i].replace(map.id(), '');
                }
                $('input[name=states]').val(keys.join(','));
                $('form[name=action_form2]').submit();
            });
            $('.states_selection legend a').on('click', function() {
                var s = $(this).find('span').html();
                if (s == '+') {
                    $(this).find('span').html('-');
                    prev.show();
                    slctd.hide();
                } else {
                    $(this).find('span').html('+');
                    prev.hide();
                    slctd.show().html(getSelectedNames());
                }
            });

            jQuery('.stateinfo input:radio').click(function(){
            var el_id = <?php echo $group_id ?>;
            //alert(jQuery(this).prop('id'));
            if(jQuery(this).prop('id').charAt(0)=='n'){
                jQuery("#URL").val("");
                jQuery("#stateURL").fadeOut(0);
                jQuery("#stateDescr").fadeOut(0);
                jQuery("#statePopup").fadeOut(0);
            }
            else if(jQuery(this).prop('id').charAt(0)=='u'){
                jQuery("#URL").val("http://");
                //jQuery("#URL").prop("readonly", false);
                jQuery("#stateURL").fadeIn(0);
                jQuery("#stateDescr").fadeOut(0);
                jQuery("#statePopup").fadeOut(0);
            }
            else if(jQuery(this).prop('id').charAt(0)=='m'){
                jQuery("#URL").val("#info");
                //jQuery("#URL").prop("readonly", false);
                jQuery("#stateURL").fadeOut(0);
                jQuery("#stateDescr").fadeIn(0);
                jQuery("#statePopup").fadeOut(0);
            }
            else if(jQuery(this).prop('id').charAt(0)=='p'){
                jQuery("#URL").val("#popup");
                jQuery("#stateURL").fadeOut(0)
                jQuery("#stateDescr").fadeOut(0);
                jQuery("#statePopup").fadeIn(0);
            }
        });

            window.send_to_editorArea = window.send_to_editor;

            window.send_to_editor = function(html) {
                if(imageFieldId === false) {
                    window.send_to_editorArea(html);
                }
                else {
                    var imgurl = jQuery('img', html).prop('src');

                    jQuery('#' + imageFieldId).val(imgurl);
                    imageFieldId = false;

                    tb_remove();
                }

            }
            try {
                tinyMCE.execCommand('mceAddControl', true, 'info');
            } catch (e) {}
        });


        function clearImage(f) {
            jQuery(f).prev().val('');
        }
    </script>
    <input type="hidden" name="states" id="states" value="" />
    <p class="submit"><input type="button" value="<?php esc_attr_e('Save Changes', 'portugal-html5-map'); ?>" class="button-primary savegroup">
    <a class="submitdelete deletion" style="color: #a00; margin: 5px 20px" href="<?php echo wp_nonce_url("?page=portugal-html5-map-groups&act_type=portugal-html5-map-groups-delete&map_id=$map_id&g_id=$group_id", "map_id=$map_id&g_id=$group_id") ?>"><?php _e('Delete', 'portugal-html5-map'); ?></a>
    </p>
<?php } ?>
    <input type="hidden" name="act_type" value="portugal-html5-map-groups-save" />
</form>
</div>
