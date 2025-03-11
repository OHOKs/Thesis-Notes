const express = require("express");
const bodyParser = require("body-parser")

const flowerRoutes = require('./routes/flowers.routes');
const categoryRoutes = require('./routes/categories.routes');

const app = express();

app.use(express.json()); 
app.use(bodyParser.urlencoded({ extended: true }));

app.use('/api', flowerRoutes); 
app.use('/api', categoryRoutes); 

const PORT = process.env.PORT || 3001;
app.listen(PORT,() => {
    console.log(`Szerver fut a http://localhost:${PORT} címen`);
});