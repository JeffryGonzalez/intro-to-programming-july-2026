export const providers = ['netflix', 'prime', 'hulu', 'disney+', 'hbo-max', 'criterion'] as const;
export type StreamingProviders = (typeof providers)[number];

export type ApiShowItem = {
  id: string;
  title: string;
  description: string;
  streamingServices: StreamingProviders[];
};
