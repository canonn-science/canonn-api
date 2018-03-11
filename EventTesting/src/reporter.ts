import { logger } from './logging';
import { EventStoreConnector } from './eventStore/eventStore'
import { CsvParser } from './csvParser';
import { raw as newGuid } from 'guid';
import { BarkMound } from './models/barkMounds';

const parser = new CsvParser();
const es = new EventStoreConnector();

parser.parse<BarkMound>('./data/barkmounds_reponses_raw.csv').then((res) => {
	res.forEach(d => {
		es.sendEntity('barkmoundReport', d.id, { eventId: newGuid(), eventType: 'barkmoundReported', data: d })
	});
});

let end = false;
setTimeout(() => end = true, 10000);

(function wait() {
	if (!end) {
		logger.log('info', 'Waiting...');
		setTimeout(wait, 1000);
	} else {
		logger.log('warning', 'End');
	}
})();
