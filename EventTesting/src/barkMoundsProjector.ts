import { logger } from './logging';
import {HeartbeatInfo, TcpEndPoint, UserCredentials, createConnection, streamPosition } from 'node-eventstore-client';

const credentials = new UserCredentials("admin", "changeit");
const connection = createConnection({}, 'tcp://localhost:1113');

connection.on('heartbeatInfo', (heartbeatInfo: HeartbeatInfo) => {
	logger.debug(`Connected to endpoint: ${heartbeatInfo.remoteEndPoint.host}:${heartbeatInfo.remoteEndPoint.port}, latency: ${heartbeatInfo.responseReceivedAt - heartbeatInfo.requestSentAt} ms`);
});
connection.on("error", error =>
	logger.error(`Error occurred on connection: ${error}`)
);
connection.on("closed", reason =>
	logger.warn(`Connection closed, reason: ${reason}`)
);
connection.once('connected', async (tcpEndPoint: TcpEndPoint) => {
	logger.info(`Connected to Event Store at ${tcpEndPoint.host}:${tcpEndPoint.port}`);
	const subscription = await connection.subscribeToStreamFrom(
		'$ce-barkmoundReport',
		streamPosition.start,
		true, // resolveLinkTos,
		(sub, resolvedEvent) => { // EventAppeared
			const event = resolvedEvent.event;
			const eventData = JSON.parse(event.data.toString('utf8'));

			logger.info(`Received event ID ${event.eventId} of TYPE ${event.eventType} from STREAM ${event.eventStreamId}`);
			logger.debug(`Cmdr ${eventData.cmdrName} reported sighting on ${eventData.systemName} ${eventData.planetName} (${eventData.latitude}, ${eventData.longitude})`);
		},
		(sub) => {
			logger.info('From now on, subscription is live for new events');
		},
		(sub, reason, error) => { // subscriptionDropped
			logger.error(!!error ? error : "Subscription dropped.");
		},
		credentials
	);
});
connection.connect();
