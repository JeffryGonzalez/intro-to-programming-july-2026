import { HttpHandler } from 'msw';
import bypassed from './bypassed-endpoints';
import showsHandler from './shows/shows';

const all: HttpHandler[] = [...showsHandler];

export const handlers: HttpHandler[] = all.filter((handler) => {
  const { method, path } = handler.info;
  if (typeof method !== 'string' || typeof path !== 'string') return true;
  return !bypassed.has(`${method} ${path}`);
});
