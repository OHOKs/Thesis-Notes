const express = require('express');
const { getAllCategories } = require('../controllers/categories.controller');
const router = express.Router();

router.get('/categories', getAllCategories);

module.exports = router;