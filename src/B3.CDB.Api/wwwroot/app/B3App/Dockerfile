### Multi Stage Build ###

### Estágio 1 - Obter o Source e gerar o build ###
FROM node:latest AS ng-builder
RUN mkdir -p /app
WORKDIR /app
COPY package.json /app
RUN npm install -g @angular/cli
RUN npm install
CMD ["ng", "serve", "--host", "0.0.0.0"]

### Estágio 2 - Subir o Source para o servidor NGINX com a app Angular ###
FROM nginx
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=ng-builder /front-end/B3App/dist/ /usr/share/nginx/html
# COPY --from=ng-builder /app/dist/front-end/B3App /usr/share/nginx/html

EXPOSE 80
