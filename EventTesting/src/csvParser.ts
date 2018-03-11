import * as fs  from 'fs';
import { promisify } from 'util';
import * as parse from 'csv-parse/lib/sync';
import { BarkMound } from './models/barkMounds';
import { raw as newGuid } from 'guid';

const readFileAsync = promisify(fs.readFile);

export class CsvParser {

	public async parse<T>(fileName: string): Promise<Array<T>> {
		var fileContents = await readFileAsync(fileName, { encoding: 'utf-8' });
		var data = parse(fileContents, {
			columns: true,
		});

		return data
			.map(element => new BarkMound(newGuid(), element))
			.sort((a, b) => a.timestamp - b.timestamp) // a bit of a hack, but dates can be subtracted to get difference ;)
			;
	}

}

