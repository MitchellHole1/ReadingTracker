FROM node:20-alpine3.20 As build
WORKDIR /usr/src/app
# Copy package.json and package-lock.json into the container
COPY package*.json package-lock.json ./
RUN npm ci
COPY ./ ./
EXPOSE 8080
RUN npm run build

FROM nginx:stable-alpine
COPY --from=build /usr/src/app/dist  /usr/share/nginx/html
COPY --from=build /usr/src/app/nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]