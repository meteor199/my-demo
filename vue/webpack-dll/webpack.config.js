var path = require('path')
var webpack = require('webpack')

module.exports = {
  entry: './src/main.ts',
  output: {
    path: path.resolve(__dirname, './dist'),
      // 打包后资源文件的前缀
      publicPath: '/dist/',
      filename: 'build.js'
  },
  module: {
    rules: [
      {
        test: /\.vue$/,
        loader: 'vue-loader',
        options: {
          loaders: {
          }
          // other vue-loader options go here
        }
      },
      {
        test: /\.js$/,
        loader: 'babel-loader',
        exclude: /node_modules/
      },
      {
        test: /\.ts$/,
        exclude: /node_modules|vue\/src/,
        loader: 'ts-loader',
        options: {
          appendTsSuffixTo: [/\.vue$/]
        }
      },
      {
        test: /\.(eot|svg|ttf|woff|woff2)(\?\S*)?$/,
        loader: 'file-loader'
      },
      {
        test: /\.(png|jpe?g|gif|svg)(\?\S*)?$/,
        loader: 'file-loader',
        query: {
          name: '[name].[ext]?[hash]'
        }
      }, {
        test: /\.css$/,
        loader: 'vue-style-loader!css-loader'
      }, {
        test: /\.less$/,
        loader: 'vue-style-loader!css-loader!less-loader'
      },
    ]
  },

  devServer: {
    historyApiFallback: true,
    noInfo: true,
    port: 8019
  },
  performance: {
    hints: false
  },
  devtool: '#eval-source-map',
  plugins:[
      new webpack.DllReferencePlugin({
      context: __dirname,
      manifest: require('./dist/vendor-jquery-manifest.json')
    }),
    new webpack.DllReferencePlugin({
      context: __dirname,
      manifest: require('./dist/vendor-vue-manifest.json')
    }),
  ]
}

if (process.env.NODE_ENV === 'production') {
  module.exports.devtool = '#source-map'
  // http://vue-loader.vuejs.org/en/workflow/production.html
  module.exports.plugins = (module.exports.plugins || []).concat([
    new webpack.DefinePlugin({
      'process.env': {
        NODE_ENV: '"production"'
      }
    }),
    new webpack.optimize.UglifyJsPlugin({
      sourceMap: true,
      compress: {
        warnings: false
      }
    }),
    new webpack.LoaderOptionsPlugin({
      minimize: true
    })
  ])
}
