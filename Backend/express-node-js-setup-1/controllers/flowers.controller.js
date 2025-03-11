const { PrismaClient } = require('@prisma/client');
const prisma = new PrismaClient();

const getAllFlowers = async (req, res) => {
  try {
    const flowers = await prisma.aruk.findMany({
      include: { kategoria: true }
    });

    if(!flowers) res.status(204).json({ message: "Nincsen feljegyzett virág"})

    res.status(200).json(flowers);
  } catch (error) {
    res.status(500).json(error);
  }
};

const getFlowerById = async (req, res) => {
  const { id } = req.params;

  if(!id) {
      res.status(400).json({ message: "Hiányos adatok" });
  }

  try {
    const flower = await prisma.aruk.findFirst({
      where: {
          id: Number(id)
      },
      include: { kategoria:true }
    })

    if(!flower) res.status(404).json({ message: "A virág nem található"})
    else res.status(200).json(flower);
  } catch (error){
    res.status(500).json(error);
  }
};

const createFlower = async (req,res) => {
    const { nev, ar, leiras, kepUrl, keszlet, kategoria } = req.body;

    if(!ar || !leiras || !kepUrl || !nev || !keszlet || !kategoria) {
        res.status(400).json({ message: "Hiányos adatok" });
    }

    try {
        const flower = await prisma.aruk.create({
          data: {
            ar,
            leiras,
            kepUrl,
            keszlet,
            nev,
            kategoria: {
                connect: {
                    id: Number(kategoria)
                }
            }
          },
        });

        res.status(200).json({ message: "Virág sikeresen létrehozva" });
      } catch (error) {
        res.status(500).json({ message: "Hiba a virág létrehozása során", error : error });
      }
}

const deleteFlowerById = async (req, res) => {
    const { id } = req.params;

    if(!id) {
        res.status(400).json({ message: "Hiányos adatok" });
    }

    const flower = await prisma.aruk.findFirst({
        where: {
            id: Number(id)
        }
    })
    
    if(!flower) res.status(404).json({ message: "A virág nem található"})

    if(!res.headersSent){
        try {
            await prisma.aruk.delete({
                where: { id: Number(id) }, 
            });
    
            res.status(200).json({message: "Virág sikeresen törölve"});
        } catch (error) {
            console.log(error)
            res.status(500).json({ message: "Hiba a virág törlése során", error });
        }
    }
  };



module.exports = { getAllFlowers, createFlower, deleteFlowerById, getFlowerById };