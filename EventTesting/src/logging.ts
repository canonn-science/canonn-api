import { createLogger, format, transports } from 'winston';

// https://github.com/winstonjs/winston#logging
// { error: 0, warn: 1, info: 2, verbose: 3, debug: 4, silly: 5 }
const level = process.env.LOG_LEVEL || "debug";

function formatParams(info) {
	const { timestamp, level, message, ...args } = info;
	const ts = timestamp.slice(0, 19).replace('T', ' ');

	return `${ts} ${level}: ${message} ${Object.keys(args).length
		? JSON.stringify(args, [''], '')
		: ''}`;
}

export const logger = createLogger({
	level: 'debug',
	format: format.json(),
	transports: [
		new transports.Console({
			format: format.combine(
				format.colorize(),
				format.timestamp(),
				format.align(),
				format.printf(formatParams),
			),
		}),
	],
});
