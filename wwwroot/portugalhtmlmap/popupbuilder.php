<?php



function portugal_html5map_plugin_popup_bulder_is_available() {
    return (function_exists('sgRegisterScripts') or class_exists('\sgpb\PopupLoader'));
}

function portugal_html5map_plugin_popup_bulder_type() {
    if (class_exists('\sgpb\PopupLoader'))
        return 2;
    if (function_exists('sgRegisterScripts'))
        return 1;

    return 0;
}

function portugal_html5map_plugin_popup_builder_can_enable_scripts(&$mapOptions) {
    if ( ! portugal_html5map_plugin_popup_bulder_is_available())
        return false;

    if (strpos($mapOptions['map_data'], '#popup'))
        return true;

    if (isset($mapOptions['points']) and is_array($mapOptions['points'])) foreach ($mapOptions['points'] as $pt) {
        if (isset($pt['link']) and $pt['link'] == '#popup')
            return true;
    }

    if (isset($mapOptions['groups']) and is_array($mapOptions['groups'])) foreach ($mapOptions['groups'] as $gr) {
        if ($gr['_act_over'] and isset($gr['link']) and $gr['link'] == '#popup')
            return true;
    }

    return false;
}

function portugal_html5map_plugin_popup_builder_queue_popups($mapPopupIds = array()) {

    static $processed  = array();

    foreach ($mapPopupIds as $popupId) {
        if (isset($processed[$popupId]))
            continue;

        if ($popup = \sgpb\SGPopup::find($popupId, array('checkActivePopupType' => false))) {
            $popup->setEvents(array());
            $processed[$popupId] = $popup;
        }
    }

    return $processed;
}

function portugal_html5map_plugin_popup_builder_enqueue_popups_to_output($popups) {
    return array_merge($popups, portugal_html5map_plugin_popup_builder_queue_popups());
}

function portugal_html5map_plugin_popup_builder_enable_scripts(&$mapOptions, $parseStates) {
    if ( !portugal_html5map_plugin_popup_builder_can_enable_scripts($mapOptions))
        return false;

    switch (portugal_html5map_plugin_popup_bulder_type()) {
        case 2:
            $popupIds = array();
            foreach ($parseStates as $state) {
                if (isset($state['link']) and $state['link'] == '#popup' and isset($state['popup-id']))
                    $popupIds[$state['popup-id']] = $state['popup-id'];
            }

            if (isset($mapOptions['points']) and is_array($mapOptions['points'])) foreach ($mapOptions['points'] as $pt) {
                if (isset($pt['link']) and $pt['link'] == '#popup' and isset($pt['popup_id']))
                    $popupIds[$pt['popup_id']] = $pt['popup_id'];
            }

            if (isset($mapOptions['groups']) and is_array($mapOptions['groups'])) foreach ($mapOptions['groups'] as $gr) {
                if ($gr['_act_over'] and isset($gr['link']) and $gr['link'] == '#popup' and isset($gr['popup-id']))
                    $popupIds[$gr['popup-id']] = $gr['popup-id'];
            }

            static $hooksRegistered = false;

            if ($popupIds) {
                portugal_html5map_plugin_popup_builder_queue_popups($popupIds);

                if (!$hooksRegistered) {
                    add_filter('sgpbLoadablePopups', 'portugal_html5map_plugin_popup_builder_enqueue_popups_to_output');
                    $scriptsLoader = new \sgpb\ScriptsLoader();
                    if (method_exists($scriptsLoader, 'setIsAdmin'))
                        $scriptsLoader->setIsAdmin(is_admin());
                    $scriptsLoader->loadToFooter();
                    $hooksRegistered = true;
                }
            }
            break;
        case 1:
            sgRegisterScripts();
            if (is_admin()) {
                require_once(SG_APP_POPUP_PATH.'/javascript/sg_popup_javascript.php');
                if (function_exists('SgFrontendScripts'))
                    SgFrontendScripts();
                elseif (class_exists('SgPopupBuilderConfig'))
                    echo SgPopupBuilderConfig::popupJsDataInit();
            }
            break;
    }

    return true;
}


function portugal_html5map_plugin_popup_builder_list_available_popups() {
    global $wpdb;
    $popups  = array();
    if (class_exists('\sgpb\PopupLoader')) {
        $_popups = \sgpb\SGPopup::getAllPopups();
        foreach ($_popups as $_) {
            $title = $_->getTitle();
            $type  = $_->getType();
            $popups[$_->getId()] = "$title - $type";
        }
    } elseif (defined('SG_APP_POPUP_FILES')) {
        $_popups = (array)$wpdb->get_results("SELECT id, CONCAT(title, ' - ', type) as title FROM ".$wpdb->prefix."sg_popup",OBJECT_K);
        foreach ($_popups as $_) {
            $popups[$_->id] = $_->title;
        }
    }

    return $popups;
}

function portugal_html5map_plugin_popup_builder_cover_old_ids(&$mapOptions) {
    $idsMapping = get_option('sgpbConvertedIds');
    if (!is_array($idsMapping))
        return false;

    $parseStates = json_decode($mapOptions['map_data'], true);
    $modified = false;

    foreach ($parseStates as &$state) {
        if (isset($state['popup-id']) and isset($idsMapping[$state['popup-id']])) {
            $state['popup-id'] = $idsMapping[$state['popup-id']];
            $modified = true;
        }
    }

    if (isset($mapOptions['points']) and is_array($mapOptions['points'])) foreach ($mapOptions['points'] as &$pt) {
        if (isset($pt['popup-id']) and isset($idsMapping[$pt['popup-id']])) {
            $pt['popup-id'] = $idsMapping[$pt['popup-id']];
            $modified = true;
        }
    }

    if (isset($mapOptions['groups']) and is_array($mapOptions['groups'])) foreach ($mapOptions['groups'] as &$gr) {
        if (isset($gr['popup-id']) and isset($idsMapping[$gr['popup-id']])) {
            $gr['popup-id'] =  $idsMapping[$gr['popup-id']];;
            $modified = true;
        }
    }

    if ($modified) {
        $mapOptions['update_time'] = time();
        $mapOptions['map_data'] = json_encode($parseStates);
    }

    return $modified;
}
