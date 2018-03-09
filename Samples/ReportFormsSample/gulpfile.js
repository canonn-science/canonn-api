/// <binding BeforeBuild='build' Clean='clean' />
const gulp = require('gulp');
const del = require('del');
const copy = require('gulp-copy');
const sass = require('gulp-sass');
const cleanCss = require('gulp-clean-css');
const rename = require('gulp-rename');

config = {
	dest: 'wwwroot/',
	targetFolders : [
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
	var folders = [];
	config.targetFolders.forEach((folder) => {
		folders.push(config.dest + folder + '/**');
		folders.push('!' + config.dest + folder);
	});

	return del(folders, { force: true });
});

gulp.task('copy', ['clean'], () => {
	config.libs.map(job => {
		return gulp.src(job.src)
			.pipe(gulp.dest(job.dest));
	});
});

gulp.task('sass', () => {
	var src = 'wwwrootSrc/styles/*.scss';
	var dest = config.dest + 'css';
	return [
		gulp.src(src)
			.pipe(sass())
			.pipe(gulp.dest(dest)),
		gulp.src(src)
			.pipe(sass())
			.pipe(cleanCss())
			.pipe(rename({ suffix: '.min' }))
			.pipe(gulp.dest(dest)),
	];
});

gulp.task('build', ['copy', 'sass']);
