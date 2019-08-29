var path = require("path");
var fs = require('fs');
var webpack = require("webpack");


module.exports = {
    entry: {
        "vue": ['vue','vue-router','vuex'],
        "jquery":["jquery"]
    },
    output: {
        path: path.join(__dirname, "dist"),
        filename: "vendor-[name]-dll.js",
        library: "[name]_[hash]"
    },
    plugins: [
        new webpack.DllPlugin({
            path: path.join(__dirname, "dist", "vendor-[name]-manifest.json"),
            name: "[name]_[hash]",
            context: __dirname
        })
    ]
}; 