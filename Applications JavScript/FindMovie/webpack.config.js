const path = require('path'); 

module.exports = {
    entry: './src/js/index.js',
    output:{
        path: path.join(__dirname, 'build'),
        filename: 'bundle.js',
        publicPath: '/build'
    },
    module: {
        rules: [
            {
                test: /\.js/,
                use: [
                    { 
                        loader: 'babel-loader',
                        options: {
                            "presets": ["@babel/preset-env"],
                            "plugins": ["@babel/plugin-transform-async-to-generator"]
                        }
                    }
                ]
            }
        ]
    }
}