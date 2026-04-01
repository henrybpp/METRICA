FROM registry.global.ccc.srvb.bo.paas.cloudcenter.corp/produban/nodejs-22-ubi9:1.4.0.RELEASE

USER root
ENV APP_HOME /opt/app
WORKDIR ${APP_HOME}
COPY . ${APP_HOME}

RUN npm install
RUN chown -R 23550:23550 /opt/app-root/src/.npm
USER 23550
WORKDIR /opt/produban

ENTRYPOINT [ "./control.sh" ]
CMD [ "start" ]
