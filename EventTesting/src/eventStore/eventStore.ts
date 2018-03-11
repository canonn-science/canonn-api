import { raw as newGuid } from 'guid';
import * as http from 'http';

export class Event {
	public eventId: string;
	public eventType: string;
	public data: object;

	constructor(eventType: string, data: any) {
		this.eventId = newGuid();
		this.eventType = eventType;
		this.data = data;
	}
}

export class EventStoreConnector {

	private _host: string;
	private _port: string;

	constructor(url?: string, port?: string) {
		this._host = (!!url)
			? url
			: 'localhost';
		this._port = (!!port)
			? port
			: '2113';
	}

	public async sendEntity(stream: string, entityId: string, data: Event): Promise<any> {
		const req = new http.ClientRequest({
			host: this._host,
			port: this._port,
			path: `/streams/${stream}-${entityId}`,
			method: 'POST',
			headers: {
				'Content-Type': 'application/vnd.eventstore.events+json',
			},
		});
		req.on('error', e => console.log(e));
		req.on('response', e => console.log(e));
		req.end(JSON.stringify([data]));
	}

}
