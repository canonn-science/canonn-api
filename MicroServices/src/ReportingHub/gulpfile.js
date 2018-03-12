/// <binding BeforeBuild='build' Clean='clean' />
const gulp = require('gulp');
const del = require('del');
const copy = require('gulp-copy');
const sass = require('gulp-sass');
const cleanCss = require('gulp-clean-css');
const rename = require('gulp-rename');
const sourcemaps = require('gulp-sourcemaps');
const runSequence = require('run-sequence');

config = {
	dest: 'wwwroot/',
	targetFolders: [
		'lib',
		'css',
	],
	libs: [
		{ // js
			src: [
				'node_modules/jquery/dist/**/*',
				'node_modules/jquery-validation/dist/**/*',
				'node_modules/jquery-validation-unobtrusive/dist/**/*',
				'node_modules/bootstrap/dist/js/**/*',
			],
			dest: 'wwwroot/lib/js',
		},
		{ // css
			src: [
				'node_modules/bootstrap/dist/css/**/*'
			],
			dest: 'wwwroot/lib/css',
		},
	],
};

gulp.task('clean', () => {
	return del([
		'wwwroot/lib/**',
		'!wwwroot/lib',
		'wwwroot/**/*.css',
		'wwwroot/**/*.css.map',
		'wwwroot/**/*.min.css',
		'wwwroot/**/*.min.css.map',
		'wwwroot/**/*.js',
		'wwwroot/**/*.js.map',
		'wwwroot/**/*.min.js',
		'wwwroot/**/*.min.js.map',
	], { force: true });
});

gulp.task('copy-dependencies', () => {
	config.libs.map(job => {
		return gulp.src(job.src)
			.pipe(gulp.dest(job.dest));
	});
});

gulp.task('styles', () => {
	return gulp.src('wwwroot/css/**/*.scss')
		.pipe(sourcemaps.init())				// Wrap tasks in sourcemap
			.pipe(sass({							// Compile SASS to CSS
				outputStyle: "expanded",
			}))
			.pipe(sourcemaps.write({			// write .css.map
				includeContent: false,
				sourceRoot: '/.'
			}))
			.pipe(gulp.dest('wwwroot/css'))	// write .css
			.pipe(sass({							// Compile SASS to compressed CSS
				outputStyle: "compressed",
			}))
			.pipe(cleanCss())						// Compress CSS
			.pipe(rename({							// append our suffix to the file name
				suffix: '.min',
			}))
			.pipe(sourcemaps.write({			// write .min.css.map
				includeContent: false,
				sourceRoot: '/.'
			}))
			.pipe(gulp.dest('wwwroot/css'));
});

gulp.task('build', ['copy-dependencies', 'styles']);
gulp.task('rebuild', ['clean'], () => {
	return gulp.start('build');
});

gulp.task('default', ['build']);
