const express = require('express');
const { getAllFlowers, createFlower, deleteFlowerById, getFlowerById } = require('../controllers/flowers.controller');
const router = express.Router();

router.get('/flowers', getAllFlowers);
router.get('/flowers/:id', getFlowerById);
router.post('/flowers', createFlower);
router.delete('/flowers/:id', deleteFlowerById);

module.exports = router;