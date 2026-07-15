import { delay, HttpHandler, HttpResponse, http } from 'msw';
import activeScenarios from '../active-scenarios';
import { ApiShowItem } from '../../app/features/shows/types';

const ENDPOINT = '/api/shows';

const typicalResponse: ApiShowItem[] = [
  {
    id: 'show-1',
    title: 'the expanse',
    description: 'A missing detective case draws Earth, Mars, and the Belt into conflict.',
    streamingServices: ['prime'],
  },
  {
    id: 'show-2',
    title: 'the bear',
    description: 'A chef returns home to run a struggling sandwich shop.',
    streamingServices: ['hulu', 'netflix'],
  },
];

const overloadedResponse: ApiShowItem[] = Array.from({ length: 50 }, (_, index) => ({
  id: `show-${index + 1}`,
  title: `show ${index + 1}`,
  description: `Catalog entry ${index + 1} for stress-testing long list rendering.`,
  streamingServices: ['netflix', 'prime'],
}));

export default [
  http.get(ENDPOINT, async () => {
    const scenario = activeScenarios[`GET ${ENDPOINT}`] ?? 'typical';

    switch (scenario) {
      case 'empty':
        return HttpResponse.json([]);
      case 'overloaded':
        return HttpResponse.json(overloadedResponse);
      case 'malformed-data':
        return HttpResponse.json([
          {
            id: 'show-bad-shape',
            title: 'incomplete show',
            description: null,
            streamingServices: null,
          },
        ]);
      case 'unauthorized':
        return HttpResponse.json(
          { type: 'about:blank', title: 'Unauthorized', status: 401 },
          { status: 401 },
        );
      case 'server-error':
        return new HttpResponse(null, { status: 500 });
      case 'slow':
        await delay(3000);
        return HttpResponse.json(typicalResponse);
      case 'slow-empty':
        await delay(3000);
        return HttpResponse.json([]);
      case 'never-resolves':
        await delay('infinite');
        return HttpResponse.json(typicalResponse);
      case 'typical':
      default:
        return HttpResponse.json(typicalResponse);
    }
  }),
] as HttpHandler[];
