cordova.define('cordova/plugin_list', function(require, exports, module) {
module.exports = [
    {
        "file": "plugins/custom.myplugin/www/myplugin.js",
        "id": "custom.myplugin.myplugin",
        "clobbers": [
            "window.mypl"
        ]
    },
    {
        "file": "plugins/custom.call4coffee/www/call4coffee.js",
        "id": "custom.call4coffee.call4coffee",
        "clobbers": [
            "window.call4coffee"
        ]
    }
];
module.exports.metadata = 
// TOP OF METADATA
{
    "cordova-plugin-geolocation": "1.0.0",
    "custom.myplugin": "0.2.3",
    "custom.call4coffee": "0.2.3"
}
// BOTTOM OF METADATA
});