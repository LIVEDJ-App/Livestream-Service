#!/bin/bash
SONAR_PROJECT="LIVEDJ-App_Livestream-Service"
SONARCLOUD_ORGANIZATION_NAME="livedj-app"
SONAR_TOKEN="$1"


dotnet tool install --global dotnet-sonarscanner || true
export PATH="$PATH:$HOME/.dotnet/tools"

dotnet sonarscanner begin: \
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
#!/bin/bash
SONAR_PROJECT="LIVEDJ-App_Livestream-Service"
SONARCLOUD_ORGANIZATION_NAME="livedj-app"
SONAR_TOKEN="$1"

echo "Starting SonarCloud Scanner..."

# Ensure the scanner is installed and in PATH
dotnet tool install --global dotnet-sonarscanner || true \
export PATH="$PATH:$HOME/.dotnet/tools"

# Start SonarCloud analysis
dotnet sonarscanner begin \
  /k:"${SONAR_PROJECT}" \
  /o:"${SONARCLOUD_ORGANIZATION_NAME}" \
  /d:sonar.login="${SONAR_TOKEN}" \
  /d:sonar.host.url="https://sonarcloud.io" \
  /d:sonar.cs.vscoveragexml.reportsPaths="coverage.xml" \
  /d:sonar.coverage.exclusions="\
    **/Livestream.Domain,\
    **/Livestream.Infrastructure/**,\
    **/Livestream.Persistence,\
    **/*Configuration.cs"

if [ $? -ne 0 ]; then
  echo "SonarScanner 'begin' step failed!"
  exit 1
fi
