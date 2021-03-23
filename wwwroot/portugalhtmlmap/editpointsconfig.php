<?php

$popups  = portugal_html5map_plugin_popup_builder_list_available_popups();
$options = portugal_html5map_plugin_get_options();
$option_keys = is_array($options) ? array_keys($options) : array();
$map_id  = (isset($_REQUEST['map_id'])) ? intval($_REQUEST['map_id']) : array_shift($option_keys) ;

$states  = $options[$map_id]['map_data'];
$states  = json_decode($states, true);

$maxRadius = 15;
$doptions= portugal_html5map_plugin_map_defaults();
$pointTypes = array(
    ""  => "Point",
    "marker" => "Marker",
	"Transparent" => "Transparent"
);

$defOptions = portugal_html5map_plugin_map_defaults('', 1, true);
foreach ($defOptions as $k => $v) {
    if (!isset($options[$map_id][$k]))
        $options[$map_id][$k] = $v;
}




if(isset($_POST['act_type']) && $_POST['act_type'] == 'portugal-html5-map-points-save') {
    $points = (isset($_POST['map_points']) and $_POST['map_points']) ?  stripcslashes($_POST['map_points']) : '{}';
    if (($dcd = json_decode($points, true)) !== null AND is_array($dcd)) {
        foreach ($dcd as $pid => &$pointData) {
            if (!empty($pointData['info']))
                $options[$map_id]['state_info'][$pid] = wp_kses_post($pointData['info']);
            else
                unset($options[$map_id]['info'][$pid]);
            unset($pointData['info']);

            if (!empty($pointData['comment']))
                $pointData['comment'] = wp_kses_post($pointData['comment']);
            if (!empty($pointData['color']) and $pointData['color'][0] != '#')
                $pointData['color'] = portugal_html5map_plugin_chk_color($pointData['color']);
            if (!empty($pointData['colorOver']) and $pointData['colorOver'][0] != '#')
                $pointData['colorOver'] = portugal_html5map_plugin_chk_color($pointData['colorOver']);
        }
        unset($pointData);
        $options[$map_id]['points'] = $dcd;
    }
    if (isset($_POST['clear_saved_state']) and $_POST['clear_saved_state']) {
        unset($options[$map_id]['point_editor_settings']);
    } else {
        $es = (isset($_POST['editor_settings']) and $_POST['editor_settings']) ?  stripcslashes($_POST['editor_settings']) : '{}';
        $options[$map_id]['point_editor_settings'] = $es;
    }
    $options[$map_id]['pointColor']             = portugal_html5map_plugin_chk_color($_POST['dPointColor']);
    $options[$map_id]['pointColorOver']         = portugal_html5map_plugin_chk_color($_POST['dPointColorOver']);
    $options[$map_id]['pointBorderColor']       = portugal_html5map_plugin_chk_color($_POST['dPointBorderColor']);
    $options[$map_id]['pointBorderColorOver']   = portugal_html5map_plugin_chk_color($_POST['dPointBorderColorOver']);
    $options[$map_id]['pointNameColor']         = portugal_html5map_plugin_chk_color($_POST['dPointNameColor']);
    $options[$map_id]['pointNameColorOver']     = portugal_html5map_plugin_chk_color($_POST['dPointNameColorOver']);
    $options[$map_id]['pointNameStroke']        = (($stroke = sanitize_text_field($_POST['dPointNameStroke'])) ? ($stroke == 'no' ? false : true) : null);
    $options[$map_id]['pointNameStrokeWidth']   = (($width = sanitize_text_field($_POST['dPointNameStrokeWidth'])) ? (max(0.1, min(3, (float) str_replace(',', '.', $width)))) : null);
    $options[$map_id]['pointNameStrokeOpacity'] = (($opacity = sanitize_text_field($_POST['dPointNameStrokeOpacity'])) ? (max(0, min(1, (float) str_replace(',', '.', $opacity)))) : null);
    $options[$map_id]['pointNameStrokeColor']   = portugal_html5map_plugin_chk_color($_POST['dPointNameStrokeColor']);
    $options[$map_id]['pointNameStrokeColorOver'] = portugal_html5map_plugin_chk_color($_POST['dPointNameStrokeColorOver']);
    $options[$map_id]['defaultPointRadius']     = min($maxRadius, max(1, (int) $_POST['dPointRadius']));
    $options[$map_id]['pointNameFontSize']      = min(20, max(3, (int) $_POST['dPointFontSize']));
    $options[$map_id]['pointNameFontFamily']    = sanitize_text_field(stripcslashes($_POST['dPointFontFamily']));
    $options[$map_id]['update_time'] = time();
    portugal_html5map_plugin_save_options($options);
}

$mce_options = array(
    //'media_buttons' => false,
    'editor_height'   => 150,
    'textarea_rows'   => 20,
    'textarea_name'   => 'pointAddInfo',
    'tinymce' => array(
        'add_unload_trigger' => false,
    )
);

$defaultEditorSettings = array(
    'color'                 => null,
    'colorOver'             => null,
    'borderColor'           => null,
    'borderColorOver'       => null,
    'nameColor'             => null,
    'nameColorOver'         => null,
    'nameStrokeColor'       => null,
    'nameStrokeColorOver'   => null,
    'nameFontSize'          => null,
    'radius'                => null,
    'textPosition'          => 'right-middle'
);

$editorSettings = (isset($options[$map_id]['point_editor_settings']) and ($settings = json_decode($options[$map_id]['point_editor_settings'], true))) ? $settings : array();
foreach ($defaultEditorSettings as $k => $v) {
    if (!array_key_exists($k, $editorSettings)) {
        $editorSettings[$k] = $v;
    }
}

echo "<div class=\"wrap\"><h2>" . __('Configuration of Map points', 'portugal-html5-map') . "</h2>";
?>
<style>
.tipsy-w {
    z-index: 50500;
}
#TB_overlay, #TB_window {
    z-index: 50150 !important;
}
.ui-dialog {
    z-index: 50000 !important;
}
#adminmenuwrap {
    z-index: 40000 !important:
}
</style>
<script>
    var imageFieldId = false;
    jQuery(function($){

        $('.tipsy-q').tipsy({gravity: 'w'}).css('cursor', 'default');

        $('.color~.colorpicker').each(function(){
            var me = this;

            $(this).farbtastic(function(color){
                var textColor = this.hsl[2] > 0.5 ? '#000' : '#fff';

                $(me).prev().prev().css({
                    background: color,
                    color: textColor
                }).val(color);

                if($(me).next().find('input').prop('checked')) {
                    return;
                    var dirClass = $(me).prev().prev().hasClass('colorSimple') ? 'colorSimple' : 'colorOver';

                    $('.'+dirClass).css({
                        background: color,
                        color: textColor
                    }).val(color);
                }
            });

            $.farbtastic(this).setColor($(this).prev().prev().val());

            $($(this).prev().prev()[0]).bind('change', function(){
                $.farbtastic(me).setColor(this.value);
            });

            $(this).hide();
            $(this).prev().prev().bind('focus', function(){
                $(this).next().next().fadeIn();
            });
            $(this).prev().prev().bind('blur', function(){
                $(this).next().next().fadeOut();
            });
        });


        window.send_to_editorArea = window.send_to_editor;

        window.send_to_editor = function(html) {
            if(imageFieldId === false) {
                window.send_to_editorArea(html);
            }
            else {
                var imgurl = $('img', html).prop('src');

                $('#'+imageFieldId).val(imgurl);
                imageFieldId = false;

                tb_remove();
            }

        }
        
        try {
            if (typeof tinyMCE !== 'undefined') tinyMCE.execCommand('mceAddControl', true, 'pointAddInfo');
        } catch (e) {}

        $('input[type=submit]').prop('disabled',false);

    });

    function adjustSubmit() {
        jQuery('#map_points').val(map.mapConfig.points ? JSON.stringify(map.mapConfig.points) : '');
        jQuery('#editor_settings').val(JSON.stringify(editorSettings));
    }

</script>
<br />
<form method="POST" class="portugal-html5-map main" onsubmit="adjustSubmit()">
<?php 
    portugal_html5map_plugin_map_selector('points', $map_id, $options);
    echo "<br /><br />\n";
    portugal_html5map_plugin_nav_tabs('points', $map_id);
?>

    <p><?php _e("Double-click to add a point; click and hold to drag; double-click a point to edit it", "portugal-html5-map"); ?></p>

    <fieldset>
        <legend><?php _e('Points Configuration', 'portugal-html5-map'); ?></legend>

        <div id="point_info"></div>
        <div>
        <div style="border-top: 1px solid #ddd">
                <label style="position: relative; top: -13px; background: white"><a href="javascript:void(0);" onclick="show_default_options(this.innerHTML.indexOf('+')!==-1)"><?php echo sprintf(__("Points defaults [%s]", "portugal-html5-map"), "<span>+</span>") ?></a></label>
                <div id="pointDefOptionsWrapp" style="display: none">
                <table style="width: 100%">
                    <thead>
                    <tr style="font-weight: bold">
                        <td><?php _e('Option', 'portugal-html5-map'); ?></td>
                        <td><?php _e('Color', 'portugal-html5-map'); ?></td>
                        <td><?php _e('Hover color', 'portugal-html5-map'); ?></td>
                    </tr>
                    </thead>
                    <tbody>
                    <tr>
                        <td><?php _e('Point color:', 'portugal-html5-map'); ?></td>
                        <td><input class="color colorSimple" type="text" name="dPointColor" id="dPointColor" value="<?php echo $options[$map_id]['pointColor'] ?>" style="background-color: <?php echo $options[$map_id]['pointColor'] ?>"  />
                        <span class="tipsy-q" original-title='<?php esc_attr_e('The color of a point.', 'portugal-html5-map'); ?>'>[?]</span><div class="colorpicker" style="margin-left: 100px"></div>
                        </td>
                        <td><input class="color colorOver" type="text" name="dPointColorOver" id="dPointColorOver" value="<?php echo $options[$map_id]['pointColorOver'] ?>" style="background-color: <?php echo $options[$map_id]['pointColorOver'] ?>"  />
                        <span class="tipsy-q" original-title='<?php esc_attr_e('The color of a point when the mouse cursor is over it.', 'portugal-html5-map'); ?>'>[?]</span><div class="colorpicker" style="margin-left: 100px"></div>
                        </td>
                    </tr>
                    <tr>
                        <td><?php _e('Border color:', 'portugal-html5-map'); ?></td>
                        <td><input class="color colorSimple" type="text" name="dPointBorderColor" id="dPointBorderColor" value="<?php echo $options[$map_id]['pointBorderColor'] ?>" style="background-color: <?php echo $options[$map_id]['pointBorderColor'] ?>"  />
                        <span class="tipsy-q" original-title='<?php esc_attr_e('The color of a point border.', 'portugal-html5-map'); ?>'>[?]</span><div class="colorpicker" style="margin-left: 100px"></div></td>
                        <td><input class="color colorOver" type="text" name="dPointBorderColorOver" id="dPointBorderColorOver" value="<?php echo $options[$map_id]['pointBorderColorOver'] ?>" style="background-color: <?php echo $options[$map_id]['pointBorderColorOver'] ?>"  />
                        <span class="tipsy-q" original-title='<?php esc_attr_e('The color of a point border when the mouse cursor is over it.', 'portugal-html5-map'); ?>'>[?]</span><div class="colorpicker" style="margin-left: 100px"></div></td>
                    </tr>
                    <tr>
                        <td><?php _e('Shortname color:', 'portugal-html5-map'); ?></td>
                        <td><input class="color colorSimple" type="text" name="dPointNameColor" id="dPointNameColor" value="<?php echo $options[$map_id]['pointNameColor'] ?>" style="background-color: <?php echo $options[$map_id]['pointNameColor'] ?>"  />
                        <span class="tipsy-q" original-title='<?php esc_attr_e('The color of a point\'s shortname.', 'portugal-html5-map'); ?>'>[?]</span><div class="colorpicker" style="margin-left: 100px"></div></td>
                        <td><input class="color colorOver" type="text" name="dPointNameColorOver" id="dPointNameColorOver" value="<?php echo $options[$map_id]['pointNameColorOver'] ?>" style="background-color: <?php echo $options[$map_id]['pointNameColorOver'] ?>"  />
                        <span class="tipsy-q" original-title='<?php esc_attr_e('The color of a point\'s shortname when the mouse cursor is over it.', 'portugal-html5-map'); ?>'>[?]</span><div class="colorpicker" style="margin-left: 100px"></div></td>
                    </tr>
                    <tr>
                        <td><?php _e('Shortname stroke color:', 'portugal-html5-map'); ?></td>
                        <td><input class="color colorSimple" type="text" name="dPointNameStrokeColor" id="dPointNameStrokeColor" value="<?php echo $options[$map_id]['pointNameStrokeColor'] ?>" style="background-color: <?php echo $options[$map_id]['pointNameStrokeColor'] ?>"  />
                        <span class="tipsy-q" original-title='<?php esc_attr_e('The color of a point\'s shortname stroke.', 'portugal-html5-map'); ?>'>[?]</span><div class="colorpicker" style="margin-left: 100px"></div></td>
                        <td><input class="color colorOver" type="text" name="dPointNameStrokeColorOver" id="dPointNameStrokeColorOver" value="<?php echo $options[$map_id]['pointNameStrokeColorOver'] ?>" style="background-color: <?php echo $options[$map_id]['pointNameStrokeColorOver'] ?>"  />
                        <span class="tipsy-q" original-title='<?php esc_attr_e('The color of a point\'s shortname stroke when the mouse cursor is over it.', 'portugal-html5-map'); ?>'>[?]</span><div class="colorpicker" style="margin-left: 100px"></div></td>
                    </tr>
                    </tbody>
                </table>
                <hr>
                <div style="float:left; width: 30%">
                    <label><span class="title"><?php _e('Radius:', 'portugal-html5-map') ?> </span>
                    <input type="number" name="dPointRadius" id="dPointRadius" value="<?php echo (int)$options[$map_id]['defaultPointRadius'] ?>" style="width: 50px" min="1" max="<?php echo $maxRadius ?>"/>
                    <span class="tipsy-q" original-title='<?php esc_attr_e('The default point radius.', 'portugal-html5-map'); ?>'>[?]</span>
                </div>
                <div style="float:left; width: 35%">
                    <label><span class="title"><?php _e('Name font family:', 'portugal-html5-map') ?> </span>
                    <input type="text" name="dPointFontFamily" id="dPointFontFamily" value="<?php echo htmlspecialchars($options[$map_id]['pointNameFontFamily']) ?>" style="width: 200px" />
                    <span class="tipsy-q" original-title='<?php esc_attr_e('The default font family for point\'s shortname.', 'portugal-html5-map'); ?>'>[?]</span></td>
                </div>
                <div style="float:left; width: 35%">
                    <label><span class="title"><?php _e('Name font size:', 'portugal-html5-map') ?> </span>
                    <input type="number" name="dPointFontSize" id="dPointFontSize" value="<?php echo (int)$options[$map_id]['pointNameFontSize'] ?>" min="3" max="20" style="width: 100px" /> px
                    <span class="tipsy-q" original-title='<?php esc_attr_e('The default font size for point\'s shortname.', 'portugal-html5-map'); ?>'>[?]</span></td>
                </div>
                <div style="float:left; width: 30%">
                    <label><span class="title"><?php _e('Name stroke:', 'portugal-html5-map') ?> </span>
                    <select name="dPointNameStroke">
                        <option value="" <?php if (is_null($options[$map_id]['pointNameStroke'])) echo 'selected="selected"'; ?>><?php _e('Use general setting', 'portugal-html5-map') ?></option>
                        <option value="yes" <?php if ($options[$map_id]['pointNameStroke'] === true) echo 'selected="selected"'; ?>><?php _e('Yes', 'portugal-html5-map') ?></option>
                        <option value="no" <?php if ($options[$map_id]['pointNameStroke'] === false) echo 'selected="selected"'; ?>><?php _e('No', 'portugal-html5-map') ?></option>
                    </select>
                    <span class="tipsy-q" original-title='<?php esc_attr_e('The default point radius.', 'portugal-html5-map'); ?>'>[?]</span>
                </div>
                <div style="float:left; width: 35%">
                    <label><span class="title"><?php _e('Stroke width:', 'portugal-html5-map') ?> </span>
                    <input type="text" name="dPointNameStrokeWidth" id="dPointNameStrokeWidth" value="<?php echo $options[$map_id]['pointNameStrokeWidth'] ?>" style="width: 50px" /> px
                    <span class="tipsy-q" original-title='<?php esc_attr_e('The default stroke width for point\'s shortname. General setting will be used if empty.', 'portugal-html5-map'); ?>'>[?]</span></td>
                </div>
                <div style="float:left; width: 35%">
                    <label><span class="title"><?php _e('Stroke opacity:', 'portugal-html5-map') ?> </span>
                    <input type="text" name="dPointNameStrokeOpacity" id="dPointNameStrokeOpacity" value="<?php echo $options[$map_id]['pointNameStrokeOpacity'] ?>" style="width: 50px" />
                    <span class="tipsy-q" original-title='<?php esc_attr_e('The default stroke opacity for point\'s shortname. General setting will be used if empty.', 'portugal-html5-map'); ?>'>[?]</span></td>
                </div>
                <div style="clear:both"></div>
        </div>
            <div style="clear:both"></div>
            <hr>
            <div style="width: 50%; float: left">
            <label><?php _e('Enable zoom:', 'portugal-html5-map') ?> <input type="checkbox" onchange="map.enableZoom(jQuery(this).prop('checked'), true)"></label>
            </div>
            <div style="width: 50%; float: left; display: none">
            <label><?php _e('Ignore editor saved state:', 'portugal-html5-map') ?> <input type="checkbox" id="ignoreES"></label>
            </div>
            <div style="clear:both"></div>
        </div>
        <hr>
        <div id="map_container"></div>
    </fieldset>
    <div style="display: none" id="dialogs">
        <div id="point_cfg">
        <?php
        $w = 32;
        $cp = count($pointTypes) > 1;
        if ($cp) $w = 25;
        if ($cp) {
        ?>
            <div style="float: left; width: <?php echo $w ?>%;">
                <label><span class="title" style="width: 80px"><?php _e('Point type:', 'portugal-html5-map') ?> </span><select name="pointType" id="pointType" >
                <?php foreach ($pointTypes as $pt => $pn) { ?>
                <option value="<?php echo $pt ?>"><?php _e($pn, 'portugal-html5-map') ?></option>
                <?php } ?>
                </select></label>
                <span class="tipsy-q" original-title="<?php esc_attr_e('Point type', 'portugal-html5-map'); ?>">[?]</span><br />
            </div>
        <?php } ?>
            <div style="float: left; width: <?php echo $w ?>%;">
                <label><span class="title" style="width: 80px"><?php _e('X position:', 'portugal-html5-map') ?> </span><input type="text" name="pointX" id="pointX" value="0" style="width: 50px"/></label>
                <span class="tipsy-q" original-title="<?php esc_attr_e('X position of the point', 'portugal-html5-map'); ?>">[?]</span><br />
            </div>
            <div style="float: left; width: <?php echo $w ?>%;">
                <label><span class="title" style="width: 80px"><?php _e('Y position:', 'portugal-html5-map') ?> </span><input type="text" name="pointY" id="pointY" value="0" style="width: 50px"/></label>
                <span class="tipsy-q" original-title="<?php esc_attr_e('Y position of the point', 'portugal-html5-map'); ?>">[?]</span><br />
            </div>
            <div style="float: left; width: <?php echo $w ?>%;">
                <label><span class="title" style="width: 80px"><?php _e('Radius:', 'portugal-html5-map') ?> </span><input type="number" name="pointRadius" id="pointRadius" value="4" style="width: 50px" min="1" max="<?php echo $maxRadius ?>"/></label>
                <span class="tipsy-q" original-title="<?php esc_attr_e('Radius of the point', 'portugal-html5-map'); ?>">[?]</span><br />
            </div>
            <hr style="clear: both"/>
            <div style="float:left; min-width: 500px">
            <label><span class="title"><?php _e('Name:', 'portugal-html5-map') ?> </span><input type="text" name="pointName" id="pointName" value=""/></label>
            <span class="tipsy-q" original-title="<?php esc_attr_e('This name will be show when mouse will be over this point', 'portugal-html5-map'); ?>">[?]</span><br />
            <label><span class="title"><?php _e('Short name:', 'portugal-html5-map') ?> </span><input type="text" name="pointShortname" id="pointShortname" value="" /></label>
            <span class="tipsy-q" original-title="<?php esc_attr_e('This name will be show near point on the map. Use \n to break the lines.', 'portugal-html5-map'); ?>">[?]</span><br />
            </div>
            <div style="float:left; min-width: 500px">
            <label><span class="title"><?php _e('Text position:', 'portugal-html5-map') ?></span><select name="pointTextPos" id="pointTextPos" style=" width: 190px">
                <option value="left-top"><?php _e('Left Top', 'portugal-html5-map') ?></option>
                <option value="left-middle"><?php _e('Left Middle', 'portugal-html5-map') ?></option>
                <option value="left-bottom"><?php _e('Left Bottom', 'portugal-html5-map') ?></option>
                <option value="middle-top"><?php _e('Center Top', 'portugal-html5-map') ?></option>
                <option value="middle-middle"><?php _e('Center Middle', 'portugal-html5-map') ?></option>
                <option value="middle-bottom"><?php _e('Center Bottom', 'portugal-html5-map') ?></option>
                <option value="right-top"><?php _e('Right Top', 'portugal-html5-map') ?></option>
                <option value="right-middle"><?php _e('Right Middle', 'portugal-html5-map') ?></option>
                <option value="right-bottom"><?php _e('Right Bottom', 'portugal-html5-map') ?></option>
            </select></label>
            <span class="tipsy-q" original-title="<?php esc_attr_e('Shortname position relative to the point', 'portugal-html5-map'); ?>">[?]</span>
            <br/>
            <label><span class="title"><?php _e('Font size:', 'portugal-html5-map'); ?></span><input type="number" name="pointFS" id="pointFS" min="3" max="20" style="width: 190px"/> px
            <span class="tipsy-q" original-title='<?php _e('Font size of the shortname displayed near the point.', 'portugal-html5-map'); ?>'>[?]</span>&nbsp;&nbsp;&nbsp;</label>
            <label for="pointFSDef"><input name="pointFSDef" id="pointFSDef" type="checkbox" /> <?php _e('Use default', 'portugal-html5-map'); ?></label>
            <br />
            </div>
            <div style="clear: both"></div>

            <div style="border-top: 1px solid #ddd">
                <label style="position: relative; top: -13px; background: white"><a href="javascript:void(0);" onclick="show_comment(this.innerHTML.indexOf('+')!==-1)"><?php echo sprintf(__("Tooltip [%s]", "portugal-html5-map"), "<span>+</span>") ?></a></label>
                <div id="pointCommentWrapp">
                    <?php portugal_html5map_plugin_wp_editor_for_tooltip('', 'pointComment', 'pointComment'); ?>
                    <br />
                    <span class="title"><?php _e('Image URL:', 'portugal-html5-map'); ?> </span>
                    <input onclick="imageFieldId = this.id; tb_show('Image', 'media-upload.php?type=image&tab=library&TB_iframe=true');" class="" type="text" id="pointImage" name="pointImage" value="" />
                    <span style="font-size: 10px; cursor: pointer;" onclick="jQuery('#pointImage').val('')"><?php _e('clear', 'portugal-html5-map'); ?></span>
                    <span class="tipsy-q" original-title="<?php esc_attr_e('The path to file of the image to display in a popup', 'portugal-html5-map'); ?>">[?]</span><br />
                </div>
            </div>
            <hr/>

            <div style="float:left; min-width: 500px">
            <span class="title"><?php _e('Point color:', 'portugal-html5-map'); ?> </span><input class="color colorSimple" type="text" name="pointColor" id="pointColor" value="" style="background-color: white"  />
            <span class="tipsy-q" original-title='<?php esc_attr_e('The color of a point.', 'portugal-html5-map'); ?>'>[?]</span><div class="colorpicker"></div>
            <label for="colorDef"><input name="colorDef" id="colorDef" class="colorOverCh" type="checkbox" /> <?php _e('Use default', 'portugal-html5-map'); ?></label>
            <br />
            </div>
            <div style="float:left; min-width: 500px">
            <span class="title"><?php _e('Point hover color:', 'portugal-html5-map'); ?> </span><input class="color colorOver" type="text" name="pointColorOver" id="pointColorOver" style="background-color: white"  />
            <span class="tipsy-q" original-title='<?php _e('The color of a point when the mouse cursor is over it.', 'portugal-html5-map'); ?>'>[?]</span><div class="colorpicker"></div>
            <label for="colorOverDef"><input name="colorOverDef" id="colorOverDef" class="colorOverCh" type="checkbox" /> <?php _e('Use default', 'portugal-html5-map'); ?></label>
            <br />
            </div>
            <div style="clear: both"></div>
            <div style="border-top: 1px solid #ddd">
                <label style="position: relative; top: -13px; background: white"><a href="javascript:void(0);" onclick="show_more_colors(this.innerHTML.indexOf('+')!==-1)"><?php echo sprintf(__("More color settings [%s]", "portugal-html5-map"), "<span>+</span>") ?></a></label>
                <div id="pointColorsWrapp">
                    <div style="float:left; min-width: 500px">
                    <span class="title"><?php _e('Border color:', 'portugal-html5-map'); ?> </span><input class="color colorSimple" type="text" name="borderColor" id="borderColor" value="" style="background-color: white"  />
                    <span class="tipsy-q" original-title='<?php esc_attr_e('The color of a point.', 'portugal-html5-map'); ?>'>[?]</span><div class="colorpicker"></div>
                    <label for="borderColorDef"><input name="borderColorDef" id="borderColorDef" class="colorOverCh" type="checkbox" /> <?php _e('Use default', 'portugal-html5-map'); ?></label>
                    <br />
                    <span class="title"><?php _e('Name color:', 'portugal-html5-map'); ?> </span><input class="color colorSimple" type="text" name="nameColor" id="nameColor" value="" style="background-color: white"  />
                    <span class="tipsy-q" original-title='<?php esc_attr_e('The color of a point.', 'portugal-html5-map'); ?>'>[?]</span><div class="colorpicker"></div>
                    <label for="nameColorDef"><input name="nameColorDef" id="nameColorDef" class="colorOverCh" type="checkbox" /> <?php _e('Use default', 'portugal-html5-map'); ?></label>
                    <br />
                    <span class="title"><?php _e('Name stroke color:', 'portugal-html5-map'); ?> </span><input class="color colorSimple" type="text" name="nameStrokeColor" id="nameStrokeColor" value="" style="background-color: white"  />
                    <span class="tipsy-q" original-title='<?php esc_attr_e('The color of a point.', 'portugal-html5-map'); ?>'>[?]</span><div class="colorpicker"></div>
                    <label for="nameStrokeColorDef"><input name="nameStrokeColorDef" id="nameStrokeColorDef" class="colorOverCh" type="checkbox" /> <?php _e('Use default', 'portugal-html5-map'); ?></label>
                    <br />
                    </div>

                    <div style="float:left; min-width: 500px">
                    <span class="title"><?php _e('Border hover color:', 'portugal-html5-map'); ?> </span><input class="color colorOver" type="text" name="borderColorOver" id="borderColorOver" style="background-color: white"  />
                    <span class="tipsy-q" original-title='<?php _e('The color of a point when the mouse cursor is over it.', 'portugal-html5-map'); ?>'>[?]</span><div class="colorpicker"></div>
                    <label for="borderColorOverDef"><input name="borderColorOverDef" id="borderColorOverDef" class="colorOverCh" type="checkbox" /> <?php _e('Use default', 'portugal-html5-map'); ?></label>
                    <br />
                    <span class="title"><?php _e('Name hover color:', 'portugal-html5-map'); ?> </span><input class="color colorOver" type="text" name="nameColorOver" id="nameColorOver" style="background-color: white"  />
                    <span class="tipsy-q" original-title='<?php _e('The color of a point when the mouse cursor is over it.', 'portugal-html5-map'); ?>'>[?]</span><div class="colorpicker"></div>
                    <label for="nameColorOverDef"><input name="nameColorOverDef" id="nameColorOverDef" class="colorOverCh" type="checkbox" /> <?php _e('Use default', 'portugal-html5-map'); ?></label>
                    <br />
                    <span class="title"><?php _e('Name stroke hover color:', 'portugal-html5-map'); ?> </span><input class="color colorOver" type="text" name="nameStrokeColorOver" id="nameStrokeColorOver" style="background-color: white"  />
                    <span class="tipsy-q" original-title='<?php _e('The color of a point when the mouse cursor is over it.', 'portugal-html5-map'); ?>'>[?]</span><div class="colorpicker"></div>
                    <label for="nameStrokeColorOverDef"><input name="nameStrokeColorOverDef" id="nameStrokeColorOverDef" class="colorOverCh" type="checkbox" /> <?php _e('Use default', 'portugal-html5-map'); ?></label>
                    <br />
                    </div>
                </div>
            </div>
            <hr style="clear: both"/>
            <span class="title"><?php _e('On click action:', 'portugal-html5-map'); ?> </span>
            <label><input type="radio" name="clickaction" id="ca-nothing" value="nothing" checked="checked" autocomplete="off"/> <?php _e('nothing', 'portugal-html5-map') ?></label>&nbsp;&nbsp;&nbsp;
            <label><input type="radio" name="clickaction" id="ca-url"     value="url"  autocomplete="off"/> <?php _e('open link', 'portugal-html5-map') ?></label>&nbsp;&nbsp;&nbsp;
            <label><input type="radio" name="clickaction" id="ca-info"    value="info" autocomplete="off"/> <?php _e('show additional information', 'portugal-html5-map') ?></label>&nbsp;&nbsp;&nbsp;
            <label><input type="radio" name="clickaction" id="ca-popup"   value="popup" autocomplete="off" <?php echo (!count($popups)) ? "disabled" : ""; ?>/> <?php _e('Show lightbox popup', 'portugal-html5-map') ?></label>&nbsp;&nbsp;&nbsp;
            <br>
            <div id="action-url" style="display: none">
            <hr style="clear: both"/>
                <span class="title"><?php _e('URL:', 'portugal-html5-map'); ?> </span><input style="width: 270px;" class="" type="text" name="pointURL" id="pointURL" value="" />
                <span class="tipsy-q" original-title="<?php esc_attr_e('Open url on click (if specified)', 'portugal-html5-map'); ?>">[?]</span></br>
                <span class="title"> </span>
                <label for="pointURLNW"><input name="pointURLNW" id="pointURLNW" class="" type="checkbox" /> <?php _e('Open url in a new window', 'portugal-html5-map'); ?></label>
            </div>
            <div id="action-info" style="display: none">
            <hr style="clear: both"/>
            <span class="title"><?php _e('Description:', 'portugal-html5-map'); ?> <span class="tipsy-q" original-title="<?php esc_attr_e('The description is displayed to the right of the map and contains contacts or some other additional information', 'portugal-html5-map'); ?>">[?]</span> </span>
            <?php wp_editor('', 'pointAddInfo', $mce_options); ?>
            </div>

            <div style="display: none" id="action-popup"><br />
                <span class="title"><?php _e('Select lightbox popup:', 'portugal-html5-map'); ?> </span>
                <select name="popup-id">
                    <?php foreach($popups as $pId => $pTitle) { ?>
                    <option value="<?php echo $pId; ?>"><?php echo $pTitle ?></option>
                    <?php } ?>
                </select>
            </div>
            <hr style="clear: both"/>
            <span class="title"><?php _e('CSS class:', 'portugal-html5-map'); ?> </span><input  type="text" name="pointClass" id="pointClass"  />
            <span class="tipsy-q" original-title='<?php _e('You can specify several CSS classes separated by space', 'portugal-html5-map'); ?>'>[?]</span>
        </div>
    </div>
    <link rel='stylesheet' href='<?php echo portugal_html5map_plugin_get_static_url('css/map.css') ?>'>
    <script type='text/javascript' src='<?php echo portugal_html5map_plugin_get_raphael_js_url() ?>'></script>
    <script type='text/javascript' src='<?php echo portugal_html5map_plugin_get_map_js_url($options[$map_id]) ?>'></script>
    <style>
        <?php echo portugal_html5map_plugin_prepare_tooltip_css($options, "#map_container") ?>
    </style>
<?php
if (isset($options[$map_id]['points'])) foreach ($options[$map_id]['points'] as $pid => &$pointData) {
    if (isset($options[$map_id]['state_info'][$pid]))
        $pointData['info'] = $options[$map_id]['state_info'][$pid];
}
unset($pointData);
if (isset($options[$map_id]['hideSN']) AND $options[$map_id]['hideSN']) {
    $data = json_decode($doptions['map_data'], true);
    $protected_shortnames = array();
    foreach ($data as $sid => &$d) {
        if (!in_array($sid, $protected_shortnames)) {
            $d['shortname'] = '';
        }
    }
    $doptions['map_data'] = json_encode($data);
}

$mapCfg = array(
        'mapWidth'      => 0,
        'mapHeight'     => 0,

        'shadowAllow'   => false,

        'zoomMax'       => $options[$map_id]['zoomMax'],
        'zoomStep'      => $options[$map_id]['zoomStep'],

        'iPhoneLink'    => $doptions['iPhoneLink'] === 'false' ? false : (!!$doptions['iPhoneLink']),
        'isNewWindow'   => $doptions['isNewWindow'] === 'false' ? false : (!!$doptions['isNewWindow']),

        'borderColor'       => $doptions['borderColor'],
        'borderColorOver'   => $doptions['borderColorOver'],

        'nameColor'         => $doptions['nameColor'],
        'nameFontSize'      => $options[$map_id]['nameFontSize'] . 'px',
        'nameFontFamily'    => portugal_html5map_plugin_escape_fonts($options[$map_id]['nameFontFamily'], 'Arial, sans-serif'),
        'nameFontWeight'    => $options[$map_id]['nameFontWeight'],

        'pointColor'            => $options[$map_id]['pointColor'],
        'pointColorOver'        => $options[$map_id]['pointColorOver'],
        'pointBorderColor'      => $options[$map_id]['pointBorderColor'],
        'pointBorderColorOver'  => $options[$map_id]['pointBorderColorOver'],
        'pointNameColor'        => $options[$map_id]['pointNameColor'],
        'pointNameColorOver'    => $options[$map_id]['pointNameColorOver'],
        'pointNameStrokeColor'      => $options[$map_id]['pointNameStrokeColor'],
        'pointNameStrokeColorOver'  => $options[$map_id]['pointNameStrokeColorOver'],
        'pointNameStroke'       => is_null($options[$map_id]['pointNameStroke']) ? ($options[$map_id]['nameStroke'] ? true : false) : ($options[$map_id]['pointNameStroke'] ? true : false),
        'pointNameStrokeWidth'  => is_null($options[$map_id]['pointNameStrokeWidth']) ? $options[$map_id]['nameStrokeWidth'] : $options[$map_id]['pointNameStrokeWidth'],
        'pointNameStrokeOpacity'=> is_null($options[$map_id]['pointNameStrokeOpacity']) ? $options[$map_id]['nameStrokeOpacity'] : $options[$map_id]['pointNameStrokeOpacity'],
        'pointNameFontSize'     => intval($options[$map_id]['pointNameFontSize']) . 'px',
        'pointNameFontFamily'   => portugal_html5map_plugin_escape_fonts($options[$map_id]['pointNameFontFamily'] ? $options[$map_id]['pointNameFontFamily'] : $options[$map_id]['nameFontFamily'], 'Arial, sans-serif'),

        'overDelay'         => $doptions['overDelay'],
        'nameStroke'        => $doptions['nameStroke'] ? true : false,
        'nameStrokeColor'   => $doptions['nameStrokeColor'],
        'nameStrokeWidth'   => $doptions['nameStrokeWidth'],
        'nameStrokeOpacity' => $doptions['nameStrokeOpacity'],
        'map_data'          => json_decode($doptions['map_data'], 1),
        'ignoreLinks'       => true,
        'points'            => (isset($options[$map_id]['points']) AND $options[$map_id]['points']) ? $options[$map_id]['points'] : new \stdClass(),
);

?>
    <script>
        var map_cfg = <?php echo json_encode($mapCfg) ?>;
<?php
    if (file_exists($params_file = dirname(__FILE__).'/static/paths.json')) {
        echo "map_cfg.map_params = ".file_get_contents($params_file).";\n";
    }
?>
        var map = new FlaShopPortugalMap(map_cfg);
        var activePoint = null;
        var editorSettings = <?php echo json_encode($editorSettings); ?>;
        jQuery(function($){
            var btnAdd = {
                'text': '<?php _e("Add", "portugal-html5-map"); ?>',
                'icons': {
                    'primary': 'ui-icon-plus'
                },
                'click' : function() {
                    var x = parseFloat(pX.val());
                    var y = parseFloat(pY.val());
                    if (isNaN(x)) x = 0;
                    if (isNaN(y)) y = 0;
                    var p = map.addPoint(x, y, pN.val(), null, pT.val());
                    var link, isnw, info = null;
                    var act = $('input[name="clickaction"]:checked').val();
                    if (act == 'url') {
                        link = pU.val();
                        isnw = pUNW.prop('checked') ? true : false;
                    } else if (act == 'info') {
                        link = '#info';
                        info = editorGet();
                    } else if (act == 'popup') {
                        link = '#popup';
                    } else {
                        link = null;
                    }
                    var attrs = {
                        shortname:          pSN.val().replace(/\\n/g, "\n"),
                        comment:            tooltipEditorGet(),
                        image:              pImg.val(),
                        'class':            pCl.val(),
                        textPos:            editorSettings.textPosition = pTP.val(),
                        radius:             editorSettings.radius = pR.val() < 1 ? 1 : (pR.val() > <?php echo $maxRadius ?> ? <?php echo $maxRadius ?> : pR.val()),
                        color:              editorSettings.color = uDC.prop('checked') ? null : pC.val(),
                        colorOver:          editorSettings.colorOver = uDCO.prop('checked') ? null : pCO.val(),
                        borderColor:        editorSettings.borderColor = uBDC.prop('checked') ? null : pBC.val(),
                        borderColorOver:    editorSettings.borderColorOver = uBDCO.prop('checked') ? null : pBCO.val(),
                        nameColor:          editorSettings.nameColor = uNDC.prop('checked') ? null : pNC.val(),
                        nameColorOver:      editorSettings.nameColorOver = uNDCO.prop('checked') ? null : pNCO.val(),
                        nameStrokeColor:    editorSettings.nameStrokeColor = uNSDC.prop('checked') ? null : pNSC.val(),
                        nameStrokeColorOver: editorSettings.nameStrokeColorOver = uNSDCO.prop('checked') ? null : pNSCO.val(),
                        link: link,
                        info: info,
                        isNewWindow: isnw,
                        popup_id: $('select[name="popup-id"]').val()
                    };
                    if (uDFS.prop('checked')) {
                        attrs.nameFontSize = null;
                        editorSettings.nameFontSize = null;
                    } else {
                        var fs = parseInt(pFS.val());
                        fs = fs < 3 ? 3 : (fs > 20 ? 20 : fs);
                        attrs.nameFontSize = fs+'px';
                        editorSettings.nameFontSize = fs;
                    }
                    map.setPointAttr(p, attrs);
                    $(this).dialog('close');
                }
            };
            var btnSave = {
                'text': '<?php _e("Apply", "portugal-html5-map"); ?>',
                'icons': {
                    'primary': 'ui-icon-save'
                },
                'click' : function() {
                    var x = parseFloat(pX.val());
                    var y = parseFloat(pY.val());
                    if (isNaN(x)) x = 0;
                    if (isNaN(y)) y = 0;
                    var link, isnw, info = null;
                    var act = $('input[name="clickaction"]:checked').val();
                    if (act == 'url') {
                        link = pU.val();
                        isnw = pUNW.prop('checked') ? true : false;
                    } else if (act == 'info') {
                        link = '#info';
                        info = editorGet();
                    } else if (act == 'popup') {
                        link = '#popup';
                    } else {
                        link = null;
                    }

                    var attrs = {
                        x: x,
                        y: y,
                        pointType:          pT.val(),
                        radius:             editorSettings.radius = pR.val() < 1 ? 1 : (pR.val() > <?php echo $maxRadius ?> ? <?php echo $maxRadius ?> : pR.val()),
                        name:               pN.val(),
                        shortname:          pSN.val().replace(/\\n/g, "\n"),
                        comment:            tooltipEditorGet(),
                        image:              pImg.val(),
                        'class':            pCl.val(),
                        textPos:            editorSettings.textPosition = pTP.val(),
                        color:              editorSettings.color = uDC.prop('checked') ? null : pC.val(),
                        colorOver:          editorSettings.colorOver = uDCO.prop('checked') ? null : pCO.val(),
                        borderColor:        editorSettings.borderColor = uBDC.prop('checked') ? null : pBC.val(),
                        borderColorOver:    editorSettings.borderColorOver = uBDCO.prop('checked') ? null : pBCO.val(),
                        nameColor:          editorSettings.nameColor = uNDC.prop('checked') ? null : pNC.val(),
                        nameColorOver:      editorSettings.nameColorOver = uNDCO.prop('checked') ? null : pNCO.val(),
                        nameStrokeColor:    editorSettings.nameStrokeColor = uNSDC.prop('checked') ? null : pNSC.val(),
                        nameStrokeColorOver: editorSettings.nameStrokeColorOver = uNSDCO.prop('checked') ? null : pNSCO.val(),
                        link: link,
                        info: info,
                        isNewWindow: isnw,
                        popup_id: $('select[name="popup-id"]').val()
                    };
                    if (uDFS.prop('checked')) {
                        attrs.nameFontSize = null;
                        editorSettings.nameFontSize = null;
                    } else {
                        var fs = parseInt(pFS.val());
                        fs = fs < 3 ? 3 : (fs > 20 ? 20 : fs);
                        attrs.nameFontSize = fs+'px';
                        editorSettings.nameFontSize = fs;
                    }
                    map.setPointAttr(activePoint, attrs);
                    $(this).dialog('close');
                    activePoint = null;
                }
            };
            var btnDelete = {
                'text': '<?php _e("Delete", "portugal-html5-map"); ?>',
                'icons': {
                    'primary': 'ui-icon-delete'
                },
                'click' : function() {
                    var name = map.fetchPointAttr(activePoint, 'name');
                    if (confirm('<?php _e("Are you sure you want to delete point", "portugal-html5-map") ?> '+name)) {
                        map.deletePoint(activePoint);
                        activePoint = null;
                        $(this).dialog('close');
                    }
                }
            };
            var btnClose = {
                'text': '<?php _e("Cancel", "portugal-html5-map"); ?>',
                'icons': {
                    'primary': 'ui-icon-close'
                },
                'click' : function() {
                    $(this).dialog('close');
                }
            };
            map.draw('map_container');
            map.on('dblclick', function(ev, sid, map){
                dlg.dialog('open');
                if (sid && map.mapConfig.points[sid]) {
                    var p = map.mapConfig.points[sid];
                    pX.val(p.x);
                    pY.val(p.y);
                    pN.val(p.name);
                    pSN.val(typeof(p.shortname) === 'string' ? p.shortname.replace(/\n/g, '\\n') : '');
                    pR.val(p.radius);
                    pU.val('http://');
                    pT.val(p.pointType);
                    var act = 'nothing';
                    editorSet('');
                    if ((p.link && /^javascript:portugalhtml5map_set_state_text/.test(p.link)) || p.link == '#info')
                    {
                        act = 'info';
                        editorSet(p.info?p.info:'');
                    }
                    else if (p.link=='#popup') {
                        act = 'popup';
                        $('select[name="popup-id"]').val(p.popup_id);
                    }
                    else if (p.link)
                        act = 'url';
                    $('#ca-'+act).prop('checked', true).click();
                    pU.val(act == 'url' && p.link ? p.link : 'http://');
                    pTP.val(p.textPos ? p.textPos : 'right-middle');
                    pUNW.prop('checked', p.isNewWindow ? true : false);
                    dlg.dialog('option', {
                        'title': '<?php _e("Edit point: %s (id: %s)", "portugal-html5-map") ?>'.replace('%s', p.name).replace('%s', sid),
                        'buttons': [btnSave, btnDelete, btnClose]
                    });
                    tooltipEditorSet(p.comment);
                    pImg.val(p.image ? p.image : '');
                    pCl.val(p.class ? p.class : '');
                    show_comment(!!p.comment);

                    if (p.color) {
                        uDC.prop('checked', false);
                        pC.val(p.color).css('backgroundColor', p.color).prop('disabled', false);
                    } else {
                        uDC.prop('checked', true);
                        pC.val(dpC.val()).css('backgroundColor', dpC.val()).prop('disabled', true);
                    }
                    if (p.colorOver) {
                        uDCO.prop('checked', false);
                        pCO.val(p.colorOver).css('backgroundColor', p.colorOver).prop('disabled', false);
                    } else {
                        uDCO.prop('checked', true);
                        pCO.val(dpCO.val()).css('backgroundColor', dpCO.val()).prop('disabled', true);
                    }

                    var smc = false;
                    if (p.borderColor) {
                        smc = true;
                        uBDC.prop('checked', false);
                        pBC.val(p.borderColor).css('backgroundColor', p.borderColor).prop('disabled', false);
                    } else {
                        uBDC.prop('checked', true);
                        pBC.val(dpBC.val()).css('backgroundColor', dpBC.val()).prop('disabled', true);
                    }
                    if (p.borderColorOver) {
                        smc = true;
                        uBDCO.prop('checked', false);
                        pBCO.val(p.borderColorOver).css('backgroundColor', p.borderColorOver).prop('disabled', false);
                    } else {
                        uBDCO.prop('checked', true);
                        pBCO.val(dpBCO.val()).css('backgroundColor', dpBCO.val()).prop('disabled', true);
                    }

                    if (p.nameColor) {
                        smc = true;
                        uNDC.prop('checked', false);
                        pNC.val(p.nameColor).css('backgroundColor', p.nameColor).prop('disabled', false);
                    } else {
                        uNDC.prop('checked', true);
                        pNC.val(dpNC.val()).css('backgroundColor', dpNC.val()).prop('disabled', true);
                    }
                    if (p.nameColorOver) {
                        smc = true;
                        uNDCO.prop('checked', false);
                        pNCO.val(p.nameColorOver).css('backgroundColor', p.nameColorOver).prop('disabled', false);
                    } else {
                        uNDCO.prop('checked', true);
                        pNCO.val(dpNCO.val()).css('backgroundColor', dpNCO.val()).prop('disabled', true);
                    }

                    if (p.nameStrokeColor) {
                        smc = true;
                        uNSDC.prop('checked', false);
                        pNSC.val(p.nameStrokeColor).css('backgroundColor', p.nameStrokeColor).prop('disabled', false);
                    } else {
                        uNSDC.prop('checked', true);
                        pNSC.val(dpNSC.val()).css('backgroundColor', dpNSC.val()).prop('disabled', true);
                    }
                    if (p.nameStrokeColorOver) {
                        smc = true;
                        uNSDCO.prop('checked', false);
                        pNSCO.val(p.nameStrokeColorOver).css('backgroundColor', p.nameStrokeColorOver).prop('disabled', false);
                    } else {
                        uNSDCO.prop('checked', true);
                        pNSCO.val(dpNSCO.val()).css('backgroundColor', dpNSCO.val()).prop('disabled', true);
                    }

                    if (p.nameFontSize) {
                        pFS.val(parseInt(p.nameFontSize)).prop('disabled', false);
                        uDFS.prop('checked', false);
                    } else {
                        pFS.val(parseInt(map.mapConfig.pointNameFontSize)).prop('disabled', true);
                        uDFS.prop('checked', true);
                    }
                    /*show_more_colors(smc);*/
                    show_more_colors(false);

                    activePoint = sid;
                } else {
                    var useSavedState = iES.prop('checked') ? false : true;
                    var color;
                    pX.val(ev.onMapX);
                    pY.val(ev.onMapY);
                    pN.val('');
                    pSN.val('');
                    pU.val('http://');
                    pT.val('');
                    pR.val((useSavedState && editorSettings.radius) ? editorSettings.radius : pDR.val());
                    pTP.val(useSavedState ? editorSettings.textPosition : 'right-middle');
                    tooltipEditorSet('');
                    pImg.val('');
                    pCl.val('');
                    show_comment(false);
                    pUNW.prop('checked', false);
                    editorSet('');
                    $('#ca-nothing').prop('checked', true).click();

                    pC.val(color = (useSavedState && editorSettings.color) ? editorSettings.color : dpC.val()).css('backgroundColor', color).prop('disabled', (useSavedState && editorSettings.color) ? false : true);
                    uDC.prop('checked', (useSavedState && editorSettings.color) ? false : true);
                    pCO.val(color = (useSavedState && editorSettings.colorOver) ? editorSettings.colorOver : dpCO.val()).css('backgroundColor', color).prop('disabled', (useSavedState && editorSettings.colorOver) ? false : true);
                    uDCO.prop('checked', (useSavedState && editorSettings.colorOver) ? false : true);

                    pBC.val(color = (useSavedState && editorSettings.borderColor) ? editorSettings.borderColor : dpBC.val()).css('backgroundColor', color).prop('disabled', (useSavedState && editorSettings.borderColor) ? false : true);
                    uBDC.prop('checked', (useSavedState && editorSettings.borderColor) ? false : true);
                    pBCO.val(color = (useSavedState && editorSettings.borderColorOver) ? editorSettings.borderColorOver : dpBCO.val()).css('backgroundColor', color).prop('disabled', (useSavedState && editorSettings.borderColorOver) ? false : true);
                    uBDCO.prop('checked', (useSavedState && editorSettings.borderColorOver) ? false : true);

                    pNC.val(color = (useSavedState && editorSettings.nameColor) ? editorSettings.nameColor : dpNC.val()).css('backgroundColor', color).prop('disabled', (useSavedState && editorSettings.nameColor) ? false : true);
                    uNDC.prop('checked', (useSavedState && editorSettings.nameColor) ? false : true);
                    pNCO.val(color = (useSavedState && editorSettings.nameColorOver) ? editorSettings.nameColorOver : dpNCO.val()).css('backgroundColor', color).prop('disabled', (useSavedState && editorSettings.nameColorOver) ? false : true);
                    uNDCO.prop('checked', (useSavedState && editorSettings.nameColorOver) ? false : true);

                    pNSC.val(color = (useSavedState && editorSettings.nameStrokeColor) ? editorSettings.nameStrokeColor : dpNSC.val()).css('backgroundColor', color).prop('disabled', (useSavedState && editorSettings.nameStrokeColor) ? false : true);
                    uNSDC.prop('checked', (useSavedState && editorSettings.nameStrokeColor) ? false : true);
                    pNSCO.val(color = (useSavedState && editorSettings.nameStrokeColorOver) ? editorSettings.nameStrokeColorOver : dpNSCO.val()).css('backgroundColor', color).prop('disabled', (useSavedState && editorSettings.nameStrokeColorOver) ? false : true);
                    uNSDCO.prop('checked', (useSavedState && editorSettings.nameStrokeColorOver) ? false : true);

                    if (useSavedState) {
                        /*show_more_colors(
                            editorSettings.color||editorSettings.colorOver||editorSettings.borderColor||editorSettings.borderColorOver||
                            editorSettings.nameColor||editorSettings.nameColorOver||editorSettings.nameStrokeColor||editorSettings.nameStrokeColorOver
                        );*/
                        show_more_colors(false);
                    } else {
                        show_more_colors(false);
                    }

                    pFS.val((useSavedState && editorSettings.nameFontSize) ? editorSettings.nameFontSize : parseInt(Math.min(20, Math.max(3, dpFS.val())))).prop('disabled', (useSavedState && editorSettings.nameFontSize) ? false : true);
                    uDFS.prop('checked', (useSavedState && editorSettings.nameFontSize) ? false : true);
                    dlg.dialog('option', {
                        'title': '<?php _e("Add new point", "portugal-html5-map") ?>',
                        'buttons': [btnAdd, btnClose]
                    });
                    activePoint = null;
                }
            });
            var lastX = 0, lastY = 0, is_moving = false;
            map.on('mousedown', function(ev, sid, map) { if (sid && map.mapConfig.points[sid]) {
                lastX = ev.onMapX;
                lastY = ev.onMapY;
                is_moving = sid;
                ev.stopPropagation();
            } });
            map.on('mouseup', function(ev, sid, map) {
                lastX = 0;
                lastY = 0;
                is_moving = false;
                });
            var round = function (x) {
                return Math.round(x * 1000) / 1000;
            };
            map.on('mousemove', function(ev, sid, map) {
                if (is_moving) {
                    var dx = ev.onMapX - lastX,
                        dy = ev.onMapY - lastY;
                    map.setPointAttr(is_moving, {
                        x: round(map.fetchPointAttr(is_moving, 'x')+dx),
                        y: round(map.fetchPointAttr(is_moving, 'y')+dy)
                    });
                    lastX = ev.onMapX;
                    lastY = ev.onMapY;
                    ev.stopPropagation();
                }
            });
            var pX = $('#pointX');
            var pY = $('#pointY');
            var pT = $('#pointType');
            var pN = $('#pointName');
            var pSN = $('#pointShortname');

            var pC  = $('#pointColor');
            var pCO = $('#pointColorOver');
            var dpC  = $('#dPointColor');
            var dpCO = $('#dPointColorOver');
            var uDC  = $('#colorDef').change(function() {
                var checked = $(this).prop('checked'), ac = null;
                pC.prop('disabled', checked ? true : false);
                if (checked)
                    pC.val(dpC.val()).css('backgroundColor', dpC.val());
                else if (activePoint && (ac = map.fetchPointAttr(activePoint, 'color')))
                    pC.val(ac).css('backgroundColor', ac);
            });
            var uDCO = $('#colorOverDef').change(function() {
                var checked = $(this).prop('checked'), ac = null;
                pCO.prop('disabled', checked ? true : false);
                if (checked)
                    pCO.val(dpCO.val()).css('backgroundColor', dpCO.val());
                else if (activePoint && (ac = map.fetchPointAttr(activePoint, 'colorOver')))
                    pCO.val(ac).css('backgroundColor', ac);
            });

            var pBC  = $('#borderColor');
            var pBCO = $('#borderColorOver');
            var dpBC  = $('#dPointBorderColor');
            var dpBCO = $('#dPointBorderColorOver');
            var uBDC  = $('#borderColorDef').change(function() {
                var checked = $(this).prop('checked'), ac = null;
                pBC.prop('disabled', checked ? true : false);
                if (checked)
                    pBC.val(dpBC.val()).css('backgroundColor', dpBC.val());
                else if (activePoint && (ac = map.fetchPointAttr(activePoint, 'borderColor')))
                    pBC.val(ac).css('backgroundColor', ac);
            });
            var uBDCO = $('#borderColorOverDef').change(function() {
                var checked = $(this).prop('checked'), ac = null;
                pBCO.prop('disabled', checked ? true : false);
                if (checked)
                    pBCO.val(dpBCO.val()).css('backgroundColor', dpBCO.val());
                else if (activePoint && (ac = map.fetchPointAttr(activePoint, 'borderColorOver')))
                    pBCO.val(ac).css('backgroundColor', ac);
            });

            var pNC  = $('#nameColor');
            var pNCO = $('#nameColorOver');
            var dpNC  = $('#dPointNameColor');
            var dpNCO = $('#dPointNameColorOver');
            var uNDC  = $('#nameColorDef').change(function() {
                var checked = $(this).prop('checked'), ac = null;
                pNC.prop('disabled', checked ? true : false);
                if (checked)
                    pNC.val(dpNC.val()).css('backgroundColor', dpNC.val());
                else if (activePoint && (ac = map.fetchPointAttr(activePoint, 'nameColor')))
                    pNC.val(ac).css('backgroundColor', ac);
            });
            var uNDCO = $('#nameColorOverDef').change(function() {
                var checked = $(this).prop('checked'), ac = null;
                pNCO.prop('disabled', checked ? true : false);
                if (checked)
                    pNCO.val(dpNCO.val()).css('backgroundColor', dpNCO.val());
                else if (activePoint && (ac = map.fetchPointAttr(activePoint, 'nameColorOver')))
                    pNCO.val(ac).css('backgroundColor', ac);
            });

            var pNSC  = $('#nameStrokeColor');
            var pNSCO = $('#nameStrokeColorOver');
            var dpNSC  = $('#dPointNameStrokeColor');
            var dpNSCO = $('#dPointNameStrokeColorOver');
            var uNSDC  = $('#nameStrokeColorDef').change(function() {
                var checked = $(this).prop('checked'), ac = null;
                pNSC.prop('disabled', checked ? true : false);
                if (checked)
                    pNSC.val(dpNSC.val()).css('backgroundColor', dpNSC.val());
                else if (activePoint && (ac = map.fetchPointAttr(activePoint, 'nameStrokeColor')))
                    pNSC.val(ac).css('backgroundColor', ac);
            });
            var uNSDCO = $('#nameStrokeColorOverDef').change(function() {
                var checked = $(this).prop('checked'), ac = null;
                pNSCO.prop('disabled', checked ? true : false);
                if (checked)
                    pNSCO.val(dpNSCO.val()).css('backgroundColor', dpNSCO.val());
                else if (activePoint && (ac = map.fetchPointAttr(activePoint, 'nameStrokeColorOver')))
                    pNSCO.val(ac).css('backgroundColor', ac);
            });

            var pR   = $('#pointRadius');
            var pDR  = $('#dPointRadius');
            var pTP  = $('#pointTextPos');
                pCmt = $('#pointComment');
            var pImg = $('#pointImage');
            var pCl  = $('#pointClass');
                pAI  = $('#pointAddInfo');
            var pFS  = $('#pointFS');
            var dpFS = $('#dPointFontSize');
            var uDFS = $('#pointFSDef').change(function() {
                pFS.prop('disabled', $(this).prop('checked') ? true : false);
            });
            var pU = $('#pointURL');
            var pUNW = $('#pointURLNW');
            var dlg = $('#point_cfg').dialog({
                'minWidth': 600,
                'width': '80%',
                'autoOpen': false,
                'dialogClass': 'portugal-html5-map',
                'buttons': []
            });
            var iES = $('#ignoreES');
            $('input[name="clickaction"]').click(function(){
                $('#action-url, #action-info, #action-popup').hide();
                $('#action-'+$('input[name="clickaction"]:checked').val()).show();
            });
            try{
            if (typeof tinyMCE !== 'undefined') tinyMCE.execCommand('mceAddControl', true, 'pointAddInfo');
            } catch (e) { console.log(e) }
        });
        var pCmt;
        var pAI;
        function show_comment(show) {
            if (typeof show == 'undefined')
                show = true;
            var w = jQuery('#pointCommentWrapp');
            var p = w.prev().find('span');
            p.html(show ? '-' : '+');
            show ? w.show() : w.hide();
        }
        function show_more_colors(show) {
            if (typeof show == 'undefined')
                show = true;
            var w = jQuery('#pointColorsWrapp');
            var p = w.prev().find('span');
            p.html(show ? '-' : '+');
            show ? w.show() : w.hide();
        }
        function show_default_options(show) {
            if (typeof show == 'undefined')
                show = true;
            var w = jQuery('#pointDefOptionsWrapp');
            var p = w.prev().find('span');
            p.html(show ? '-' : '+');
            show ? w.show() : w.hide();
        }
        function editorSet(txt) {
            if (jQuery('#wp-pointAddInfo-wrap').hasClass('tmce-active') && tinyMCE.get('pointAddInfo')) {
                tinyMCE.get('pointAddInfo').setContent(txt);
            } else {
                pAI.val(txt);
            }
        }
        function editorGet() {
            if (jQuery('#wp-pointAddInfo-wrap').hasClass('tmce-active') && tinyMCE.get('pointAddInfo')) {
                return tinyMCE.get('pointAddInfo').getContent();
            } else {
                return pAI.val();
            }
        }
        function tooltipEditorSet(txt) {
            if (jQuery('#wp-pointComment-wrap').hasClass('tmce-active') && tinyMCE.get('pointComment')) {
                tinyMCE.get('pointComment').setContent(txt);
            } else {
                pCmt.val(txt);
            }
        }
        function tooltipEditorGet() {
            if (jQuery('#wp-pointComment-wrap').hasClass('tmce-active') && tinyMCE.get('pointComment')) {
                return tinyMCE.get('pointComment').getContent();
            } else {
                return pCmt.val();
            }
        }
    </script>
    <input type="hidden" name="act_type" value="portugal-html5-map-points-save" />
    <input type="hidden" name="map_points"  id="map_points"  />
    <input type="hidden" name="points_info" id="points_info" />
    <input type="hidden" name="editor_settings" id="editor_settings" />
    <p class="submit">
        <input type="submit" value="<?php esc_attr_e('Save Changes', 'portugal-html5-map'); ?>" class="button-primary" id="submit" name="submit" disabled>
        &nbsp;&nbsp;&nbsp;
        <label style="display: none"><input type="checkbox" name="clear_saved_state" /> <?php _e('Clear editor saved state'); ?></label>
    </p>
</form>
</div>
