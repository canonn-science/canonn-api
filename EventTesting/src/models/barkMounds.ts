import * as moment from 'moment';

export class BarkMound {

	public id: string;
	public added: boolean;
	public internalNotes: string;
	public timestamp: Date;
	public cmdrName: string;
	public systemName: string;
	public planetName: string;
	public latitude: number;
	public longitude: number;
	public screenshotUrl: string;
	public itemCount: number;
	public postUrl: string;
	public comments: string;

	constructor(id: string, csvData?: object) {
		this.id = id;
		if (!!csvData) {
			this.added = csvData['Added?'] === 'Y';
			this.internalNotes = csvData['Notes'];
			this.timestamp = moment(csvData['Timestamp'], 'M/D/YYYY HH:mm:ss').toDate();
			this.cmdrName = csvData['CMDR Name'];
			this.systemName = csvData['System'];
			this.planetName = csvData['Planet'];
			this.latitude = csvData['Latitude'];
			this.longitude = csvData['Longitude'];
			this.screenshotUrl = csvData['Screenshot'];
			this.itemCount = csvData['Optional Count of Bark Mounds at this site'];
			this.postUrl = csvData['Optional URL to Forum-post'];
			this.comments = csvData['Questions, Comments, and Concerns'];
		}
	}
}
