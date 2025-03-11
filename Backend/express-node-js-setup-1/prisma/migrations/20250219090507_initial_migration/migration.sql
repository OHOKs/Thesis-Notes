-- CreateTable
CREATE TABLE `kategoriak` (
    `id` INTEGER NOT NULL AUTO_INCREMENT,
    `nev` VARCHAR(191) NOT NULL,

    PRIMARY KEY (`id`)
) DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- CreateTable
CREATE TABLE `aruk` (
    `id` INTEGER NOT NULL AUTO_INCREMENT,
    `nev` VARCHAR(191) NOT NULL,
    `kategoriaId` INTEGER NOT NULL,
    `leiras` VARCHAR(191) NOT NULL,
    `keszlet` INTEGER NOT NULL,
    `ar` INTEGER NOT NULL,
    `kepUrl` VARCHAR(191) NOT NULL,

    PRIMARY KEY (`id`)
) DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- AddForeignKey
ALTER TABLE `aruk` ADD CONSTRAINT `aruk_kategoriaId_fkey` FOREIGN KEY (`kategoriaId`) REFERENCES `kategoriak`(`id`) ON DELETE RESTRICT ON UPDATE CASCADE;
