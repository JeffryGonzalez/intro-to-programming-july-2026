export const providers = ['netflix', 'prime', 'hulu', 'paramount', 'appletv'] as const;
export type StreamingProviders = (typeof providers)[number];

export type ApiShowItem = {
  id: string;
  title: string;
  description: string;
  streamingServices: StreamingProviders[];
};

// The Type is a program language.
export type ProviderFlags = {
  [P in StreamingProviders as `on${Capitalize<P>}`]: boolean;
};

export type ShowCreate = Pick<ApiShowItem, 'title' | 'description'> & {
  streamingProviders: ProviderFlags & {
    otherStreamingService: string;
  };
};

// interface ShowCreate implements ProviderFlags, Pick<ApiShowItem, 'title' | 'description'> {
//   otherStreamingService: string
// }
