import { ChangeEvent, FormEvent, useState } from "react";
import { useProductContext } from "../store/ProductContext";
import "./styles.css";
import { Product } from "../store/Product";

export default function AddProduct() {
    const emptyProduct: Product = { category: '', name: '', price: 0, productCode: '', sku: '', stockQuantity: 0, dateAdded: new Date };
    let [product, setProduct] = useState<Product>(emptyProduct);
    let { AddProduct, Error } = useProductContext();

    async function handleSaveProduct(e: FormEvent<HTMLFormElement>) {
        e.preventDefault();
        await AddProduct(product);
        if (Error === '')
            setProduct(emptyProduct);      
    }

    function handleNameChange(e: ChangeEvent<HTMLInputElement>) { setProduct({ ...product, name: e.target.value }) }
    function handleCategoryChange(e: ChangeEvent<HTMLInputElement>) { setProduct({ ...product, category: e.target.value }) }
    function handleCodeChange(e: ChangeEvent<HTMLInputElement>) { setProduct({ ...product, productCode: e.target.value }) }
    function handleSkuChange(e: ChangeEvent<HTMLInputElement>) { setProduct({ ...product, sku: e.target.value }) }
    function handleQuantityChange(e: ChangeEvent<HTMLInputElement>) { if(+e.target.value >0) setProduct({ ...product, stockQuantity: +e.target.value }) }
    function handlePriceChange(e: ChangeEvent<HTMLInputElement>) { if(+e.target.value >0) setProduct({ ...product, price: +e.target.value }) }

    function isInvalid(): boolean | undefined {
        return product.name === '' || product.category === '' || product.sku === ''
            || product.productCode === '' || product.price === 0 || product.stockQuantity === 0;
    }

    return (
        <form onSubmit={handleSaveProduct} id="add-product" data-testid="addProductForm">
            <p>
                <label htmlFor="name" className="requiredLabel">Name:</label>
                <input type="text" id="name" value={product.name} onChange={handleNameChange} maxLength={80} placeholder="Enter Product Name"/>
                <label htmlFor="category">Category:</label>
                <input type="text" id="category" value={product.category} onChange={handleCategoryChange} maxLength={50} placeholder="Enter Product Category"/>
            </p>
            <p>
                <label htmlFor="code">Product Code:
                </label>
                <input type="text" id="code" value={product.productCode} onChange={handleCodeChange} maxLength={10} placeholder="Enter Product Code"/>
                <label htmlFor="sku">SKU:
                </label>
                <input type="text" id="sku" value={product.sku} onChange={handleSkuChange} maxLength={10} placeholder="Enter Product SKU"/>
            </p>
            <p>
                <label htmlFor="quantity">Stock Quantity:
                </label>
                <input type="number" id="quantity" value={product.stockQuantity} onChange={handleQuantityChange} placeholder="Enter Product Quantity"/>
                <label htmlFor="price">Price:
                </label>
                <input type="number" id="price" value={product.price} onChange={handlePriceChange} placeholder={isInvalid() ? "Enter Product Price":""} />
            </p>
            <p>
                <button  disabled={isInvalid()} title="Click to save this product" data-testid="saveButton">Add Product</button>
            </p>
        </form>
    )
}


