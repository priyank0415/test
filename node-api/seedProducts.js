const mongoose = require('mongoose');
const Product = require('./models/product');

// Sample products data
const products = [
    {
        name: "Smartphone X",
        description: "Latest smartphone with advanced features",
        price: 999.99,
        stockQuantity: 50
    },
    {
        name: "Laptop Pro",
        description: "High-performance laptop for professionals",
        price: 1499.99,
        stockQuantity: 30
    },
    {
        name: "Wireless Headphones",
        description: "Premium noise-cancelling wireless headphones",
        price: 299.99,
        stockQuantity: 100
    },
    {
        name: "Smart Watch",
        description: "Fitness tracker and smart watch combo",
        price: 199.99,
        stockQuantity: 75
    },
    {
        name: "Tablet Mini",
        description: "Compact tablet for everyday use",
        price: 399.99,
        stockQuantity: 40
    }
];

// Connect to MongoDB
mongoose.connect('mongodb://localhost:27017/techspeck', {
    useNewUrlParser: true,
    useUnifiedTopology: true
})
.then(() => {
    console.log('Connected to MongoDB');
    // Delete existing products
    return Product.deleteMany({});
})
.then(() => {
    console.log('Deleted existing products');
    // Insert new products
    return Product.insertMany(products);
})
.then(() => {
    console.log('Successfully seeded products');
    process.exit(0);
})
.catch((err) => {
    console.error('Error seeding products:', err);
    process.exit(1);
}); 