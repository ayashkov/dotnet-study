// Karma configuration file, see link for more information
// https://karma-runner.github.io/1.0/config/configuration-file.html

module.exports = function (config) {
    config.set({
        basePath: '',
        frameworks: [
            'jasmine',
            '@angular-devkit/build-angular'
        ],
        plugins: [
            require('karma-jasmine'),
            require('karma-chrome-launcher'),
            require('@angular-devkit/build-angular/plugins/karma')
        ],
        client: {
            clearContext: false // leave Jasmine Spec Runner output visible in browser
        },
        reporters: ['progress'],
        port: 12012,
        logLevel: config.LOG_INFO,
        colors: false,
        autoWatch: false,
        singleRun: true,
        restartOnFileChange: false,
        customLaunchers: {
            CustomChrome: {
                base: 'ChromeHeadless',
                flags: [
                    '--disable-gpu',
                    '--disable-features=VizDisplayCompositor'
                ]
            }
        },
        browsers: ['CustomChrome']
    });
};
