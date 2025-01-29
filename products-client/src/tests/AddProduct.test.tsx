
import { render, screen, fireEvent } from '@testing-library/react';
import AddProduct from '../components/AddProduct';
import ProductContextProvider from '../store/ProductContext';
import { describe, expect, it, vi } from 'vitest';


describe('Add Product', () => {
  it('Renders the form to add products', () => {
    render(
      <ProductContextProvider>
        <AddProduct />
      </ProductContextProvider>)
    expect(screen.getByText('Name:')).toBeTruthy();
    expect(screen.getByText('Category:')).toBeTruthy();
    expect(screen.getByText('Product Code:')).toBeTruthy();
    expect(screen.getByText('SKU:')).toBeTruthy();
    expect(screen.getByText('Stock Quantity:')).toBeTruthy();
    expect(screen.getByText('Price:')).toBeTruthy();    
  }),
  it('Renders the Save Button', () => {
    render(
      <ProductContextProvider>
        <AddProduct />
      </ProductContextProvider>)
  
    const handleSaveProduct = vi.fn();
    const form = screen.getByTestId('addProductForm');    
    const saveButton = screen.getByTestId('saveButton');
    form.onsubmit = handleSaveProduct;
    expect(saveButton).toBeTruthy();
    fireEvent.click(saveButton);
    expect(handleSaveProduct).toBeCalledTimes(0); //Button is displayed and disabled initially
  })
    
})

