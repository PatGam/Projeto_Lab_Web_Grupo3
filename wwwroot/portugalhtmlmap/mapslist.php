<?php

$update   = false;
$options  = portugal_html5map_plugin_get_options();
$goptions = portugal_html5map_plugin_get_options(null, 'portugalhtml5map_goptions');

if (isset($_REQUEST['action'])) {
    switch ($_REQUEST['action']) {
        case 'map_import':
            if (portugal_html5map_plugin_import($errors))
                portugal_html5map_plugin_messages(array(__('Configuration successfully imported!', 'portugal-html5-map')), null);
            else
                portugal_html5map_plugin_messages(null, $errors);
            break;
        case 'new':
            $type      = 1;
            $name      = sanitize_text_field($_REQUEST['name']);
            $defaults  = portugal_html5map_plugin_map_defaults($name, $type);
            if ($defaults) {
                $options[] = $defaults;
                $update    = true;
            }
            break;
        case 'delete':
            portugal_html5map_plugin_delete_action();
            break;
    }
}

if ($update) portugal_html5map_plugin_save_options($options);

if (isset($_REQUEST['goptions']) && is_array($_REQUEST['goptions'])) {

    $goptions = array(
        "roles" => (array)array_map('sanitize_text_field', $_REQUEST['goptions']['roles']),
    );

    portugal_html5map_plugin_save_options($goptions, null, 'portugalhtml5map_goptions');
}

function portugal_html5map_plugin_delete_action() {
    $options = portugal_html5map_plugin_get_options();
    $map_id = isset($_REQUEST['map_id']) ? $_REQUEST['map_id'] : array();
    if ( ! is_array($map_id))
        $map_id = explode(',', $map_id);

    if ( ! $map_id)
        return;

    foreach ($map_id as $id) {
        if ( ! isset($options[$id])) {
            echo '<script>document.location.href="?page=portugal-html5-map-maps"</script>';
            exit;
        }
    }
    if ($_SERVER['REQUEST_METHOD'] == 'POST') {
        check_admin_referer('delete');
        foreach ($map_id as $id) {
            unset($options[$id]);
        }
        portugal_html5map_plugin_save_options($options);
        echo '<script>document.location.href="?page=portugal-html5-map-maps"</script>';
        exit;
    } else {
    $names = array();
    foreach ($map_id as $id) {
        $names[] = $options[$id]['name'];
    }
?>
<form method="post">
<?php echo wp_nonce_field('delete'); ?>
<input type="hidden" name="map_id" value="<?php echo implode(',', $map_id) ?>">
<h1><?php _e('Delete map', 'portugal-html5-map') ?></h1>
<p><?php echo sprintf(_n('You are going to delete following map: <b>%s</b>.', 'You are going to delete following maps: <b>%s</b>.', count($names), 'portugal-html5-map'), implode(', ', $names)) ?></p>
<p><?php _e('<b style="color: red">Attention!</b> All settings for the map will be deleted permanently!', 'portugal-html5-map') ?></p>
<p><?php _e('Are you sure?', 'portugal-html5-map') ?></p>
<br><br><br><br>
<a class="button button-primary" href="?page=portugal-html5-map-maps"><?php _e('No, return back', 'portugal-html5-map'); ?></a>&nbsp;&nbsp;&nbsp;&nbsp;<button class="button deletion"><?php _e('Yes, delete', 'portugal-html5-map') ?></button>
</form>
<?php
    exit;
    }
}

class Map_List_Table extends WP_List_Table {

    public function __construct($arr = array())
    {
        parent::__construct(array(
                'singular' => 'id',
                'plural'   => 'id'
            ));
    }

    public function prepare_items()
    {
        $columns  = $this->get_columns();
        $hidden   = $this->get_hidden_columns();
        $sortable = $this->get_sortable_columns();

        $data     = $this->table_data();
        usort( $data, array( &$this, 'sort_data' ) );

        $this->_column_headers = array($columns, $hidden, $sortable);
        $this->items = $data;
    }

    public function get_columns()
    {
        $columns = array(
            'checkbox'  => '<input type="checkbox" class="maps_toggle" autocomplete="off" />',
            'name'      => __('Name', 'portugal-html5-map'),
            'shortcode' => __('ShortCode', 'portugal-html5-map'),
            'edit'      => __('Edit', 'portugal-html5-map'),
        );

        return $columns;
    }

    public function get_bulk_actions()
    {
        return array(
            'delete' => __('Delete', 'portugal-html5-map'),
            /*'portugal-html5-map-export' => __('Export', 'portugal-html5-map')*/
        );
    }

    public function get_hidden_columns()
    {
        return array();
    }

    public function get_sortable_columns()
    {
        return array(
            'name' => array('name', false),
        );
    }

    private function table_data()
    {

        $data      = array();
        $options   = portugal_html5map_plugin_get_options();

        foreach ($options as $map_id => $map_data) {
            $data[] = array(
                            'id'        => $map_id,
                            'name'      => $map_data['name'],
                            'shortcode' => '[portugalhtml5map id="'.$map_id.'"]',
                            'edit'      => '<div style="float: left"><a href="admin.php?page=portugal-html5-map-options&map_id='.$map_id.'">'.__('General settings', 'portugal-html5-map').'</a><br />
                                            <a href="admin.php?page=portugal-html5-map-states&map_id='.$map_id.'">'.__('Detailed settings', 'portugal-html5-map').'</a><br />'.
                                            '<a href="admin.php?page=portugal-html5-map-groups&map_id='.$map_id.'">'.__('Groups settings', 'portugal-html5-map').'</a><br />'.
                                            '<a href="admin.php?page=portugal-html5-map-points&map_id='.$map_id.'">'.__('Points settings', 'portugal-html5-map').'</a><br />'.
                                            '<a href="admin.php?page=portugal-html5-map-tools&map_id='.$map_id.'">'.__('Tools', 'portugal-html5-map').'</a><br />'.
                                            '<a href="admin.php?page=portugal-html5-map-view&map_id='.$map_id.'">'.__('Preview', 'portugal-html5-map').'</a><br /><br /></div>
                                            <div style="float: right; padding-right: 20px;">
                                            <a href="admin.php?page=portugal-html5-map-maps&action=delete&map_id='.$map_id.'" class="delete" style="color:#FF0000">'.__('Delete', 'portugal-html5-map').'</a><br />
                                            </div>
                                            ',
                            );
        }

        return $data;
    }

    public function column_default( $item, $column_name )
    {

        switch( $column_name ) {
            case 'checkbox':
                echo '&nbsp;<input type="checkbox" name="map_id[]" value="'.$item['id'].'" class="map_checkbox" autocomplete="off" />';
                break;
            case 'name':
            case 'shortcode':
            case 'edit':
                return $item[ $column_name ];
        }
    }

    private function sort_data( $a, $b )
    {
        // Set defaults
        $orderby = 'name';
        $order   = 'asc';

        // If orderby is set, use this as the sort column
        if(!empty($_GET['orderby']))
        {
            $orderby = $_GET['orderby'];
        }

        // If order is set use this as the order
        if(!empty($_GET['order']))
        {
            $order = $_GET['order'];
        }

        $result = strcmp( $a[$orderby], $b[$orderby] );

        if($order === 'asc')
        {
            return $result;
        }

        return -$result;
    }

    public function get_table_classes()
    {
        $list = parent::get_table_classes();
        return $list;
    }

}


$listtable = new Map_List_Table();
$listtable->prepare_items();

?>

    <style>
        .column-shortcode {
            min-width: 150px
        }
        .column-edit {
            width: 220px;
        }
    </style>

    <div class="wrap portugal-html5-map full">
        <div id="icon-users" class="icon32"></div>
        <h2><?php echo __('Maps dashboard', 'portugal-html5-map'); ?></h2>

        <form name="action_form" action="" method="POST" enctype="multipart/form-data" class="" style="margin-top: 20px">
            <input type="hidden" name="action" value="new" />
            <input type="hidden" name="maps" value="" />

            <fieldset>
                <legend><?php echo __('Add new map', 'portugal-html5-map'); ?></legend>
                <span><?php echo __('New map name:', 'portugal-html5-map'); ?></span>
                <input type="text" name="name" value="<?php echo __('New map', 'portugal-html5-map'); ?>" />
                <input type="submit" class="button button-primary" value="<?php echo __('Add new map', 'portugal-html5-map'); ?>" />
                <div style="display: none">
                    <input type="file" name="import_file" />
                </div>
            </fieldset>
        </form>

        <form action="admin.php?page=portugal-html5-map-maps">
        <input type="hidden" name="page" value="portugal-html5-map-maps">
        <?php $listtable->display(); ?>
        </form>

        <form name="action_form2" action="" method="POST" enctype="multipart/form-data" class="" style="margin-top: 20px;">
            <fieldset>
                <legend><?php echo __('Export/import', 'portugal-html5-map') ?></legend>
                <p><?php echo __('To export please select a checkbox of one or more maps, and press Export button', 'portugal-html5-map'); ?></p>
                <input type="button" class="button button-secondary export" value="<?php echo __('Export', 'portugal-html5-map'); ?>" />
                <input type="button" class="button button-secondary import" value="<?php echo __('Import', 'portugal-html5-map'); ?>" />
            </fieldset>
        </form>

        <?php if (current_user_can('manage_options')) { ?>
        
        <form name="action_form3" action="" method="POST">
            <fieldset>
                <legend><?php echo __('Access rights to plugin settings', 'portugal-html5-map') ?></legend>
                    <p><?php echo __('This option enables access to plug-in settings for users with the "Editor" role.', 'portugal-html5-map'); ?></p>

                <ul>
                    <li>
                        <p>
                            <input type="hidden" name="goptions[roles][editor]" value="0" />
                            <input type="checkbox" name="goptions[roles][editor]" value="1" id="role_editor" <?php echo (isset($goptions['roles']['editor']) and intval($goptions['roles']['editor'])) ? "checked" : ""; ?>/>
                            <label for="role_editor"><?php echo __('Editor', 'portugal-html5-map') ?></label>
                        </p>
                    </li>
                </ul>

                <input type="submit" class="button button-primary" value="<?php echo __('Save', 'portugal-html5-map'); ?>" />
            </fieldset>
        </form>

        <?php } ?>

    </div>

    <script type="text/javascript">
        jQuery(document).ready(function() {

            /*jQuery('a.delete').click(function() {
                if (confirm('<?php echo __('Remove the map?\nAttention! All settings for the map will be deleted permanently!', 'portugal-html5-map'); ?>')) {
                    return true;
                } else {
                    return false;
                }
            });*/

            jQuery('.maps_toggle').click(function() {
                jQuery('.map_checkbox,.maps_toggle').not(jQuery(this)).each(function() {
                    jQuery(this).prop('checked', !(jQuery(this).is(':checked')));
                });
            });

            jQuery('input.export').click(function() {
                if (!jQuery('.map_checkbox:checked').size()) {
                    alert('<?php _e('Select maps you want to export first!', 'portugal-html5-map') ?>');
                    return false;
                }
                jQuery('input[name=action]').val('portugal-html5-map-export');

                var maps = '';
                jQuery('.map_checkbox:checked').each(function() {
                    if (maps!='') maps+=',';
                    maps+=jQuery(this).val();
                });

                jQuery('input[name=maps]').val(maps);

                jQuery('form[name=action_form]').submit();
                return false;
            });

            jQuery('input.import').click(function() {
                jQuery('input[name=import_file]').click();
                return false;
            });
            jQuery('.button-primary').click(function() {
                jQuery('input[name=action]').val('new');
            });

            jQuery('input[name=import_file]').change(function() {
                jQuery('input[name=action]').val('map_import');
                jQuery('form[name=action_form]').submit();
            });
        });
    </script>

<?php

?>
