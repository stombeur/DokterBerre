# uninstall if anything's already there
GRANT ALL PRIVILEGES ON *.* TO 'dokter'@'%';
DROP USER 'dokter'@'%';
DROP DATABASE IF EXISTS `dokterberre`;

# create the user
CREATE USER 'dokter'@'%' IDENTIFIED BY 'berre';
CREATE DATABASE IF NOT EXISTS `dokterberre`;
GRANT ALL PRIVILEGES ON `dokterberre` . * TO 'dokter'@'%';