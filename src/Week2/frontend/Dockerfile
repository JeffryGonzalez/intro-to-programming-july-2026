# syntax=docker/dockerfile:1

# ---- Build stage ----
FROM node:24-alpine AS build
WORKDIR /app

# Install deps first for better layer caching
COPY package.json package-lock.json ./
RUN npm ci

# Build the Angular app (production configuration)
COPY . .
RUN npm run build

# ---- Runtime stage ----
FROM nginx:1.27-alpine AS runtime

# Replace default site config with our SPA-aware config
COPY nginx.conf /etc/nginx/conf.d/default.conf

# The @angular/build:application builder emits to dist/<project>/browser
COPY --from=build /app/dist/frontend/browser /usr/share/nginx/html

EXPOSE 80

# nginx:alpine ships a sensible default CMD; keep it in the foreground
CMD ["nginx", "-g", "daemon off;"]
