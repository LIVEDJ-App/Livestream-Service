#!/bin/bash
SONAR_PROJECT="LIVEDJ-App_Livestream-Service"
SONARCLOUD_ORGANIZATION_NAME="livedj-app"
SONAR_TOKEN="$1"

dotnet-sonarscanner begin
   /k:"${SONAR_PROJECT}" \
  /d:"sonar.login=${SONAR_TOKEN}" \
  /o:"${SONARCLOUD_ORGANIZATION_NAME}" \
  /d:"sonar.host.url=https://sonarcloud.io" \
  /d:sonar.cs.vscoveragexml.reportsPaths=coverage.xml \
  /d:sonar.coverage.exclusions="\
    **/Livestream.Domain,\
    **/Livestream.Infrastructure/**,\
    **/Livestream.Persistence,\
    **/*Configuration.cs"\
