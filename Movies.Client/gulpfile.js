"use strict"

const gulp = require('gulp');
const plumber = require('gulp-plumber');
const uglify = require('gulp-uglify');
const sourcemaps = require('gulp-sourcemaps');

const browserify = require('browserify');
const browserifyShim = require('browserify-shim');
const vueify = require('vueify');
const babelify = require('babelify');
const envify = require('envify');
const watchify = require('watchify');

const source = require('vinyl-source-stream');
const buffer = require('vinyl-buffer');

const bs = require('browser-sync').create();

function createBundler(args) {
    return browserify('./src/main.js', args)
        .transform(browserifyShim)
        .transform(vueify)
        .transform(babelify)
        .transform(envify);
}

function bundle(bundler, dest = 'dist') {
    return bundler.bundle()
        .pipe(plumber())
        .pipe(source('app.js'))
        .pipe(buffer())
        .pipe(sourcemaps.init())
        .pipe(uglify())
        .pipe(sourcemaps.write('.'))
        .pipe(gulp.dest(dest));
}

const browserifyconf = {};

gulp.task('build', function() {
    process.env.NODE_ENV = 'production';
    let args = Object.assign({}, browserifyconf, { debug: true });
    const bundler = createBundler(args);
    return bundle(bundler);
});

gulp.task('watch', function() {
    process.env.NODE_ENV = 'development';
    let args = Object.assign({}, watchify.args, browserifyconf, { debug: true });
    const bundler = createBundler(args).plugin(watchify);
    bundle(bundler, 'dev');
    bundler.on('update', function() {
        bundle(bundler, 'dev').pipe(bs.reload({ stream: true }));
    });
});

gulp.task('serve', ['watch'], function() {
    bs.init({
        server: {
            baseDir: './',
            index: 'index.html'
        },
        serveStatic: [{
            route: '/dist',
            dir: './dev'
        }]
    });
});
