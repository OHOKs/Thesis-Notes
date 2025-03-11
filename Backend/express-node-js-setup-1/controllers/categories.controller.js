const { PrismaClient } = require('@prisma/client');
const prisma = new PrismaClient();

const getAllCategories = async (req, res) => {
  try {
    const categories = await prisma.kategoriak.findMany();

    if(!categories) res.status(204).json({ message: "Nincsen feljegyzett kategória"})

    res.status(200).json(categories);
  } catch (error) {
    res.status(500).json(error);
  }
};

module.exports = { getAllCategories };