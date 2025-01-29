
import { render, screen, } from '@testing-library/react';
import ProductContextProvider from '../store/ProductContext';
import { describe, expect, it, } from 'vitest';
import ProductsTable from '../components/ProductsTable';


describe('Product Products table', () => {
  it('Renders the grid', () => {
    render(
      <ProductContextProvider>
        <ProductsTable />
      </ProductContextProvider>)
    //checking the grid headers
    expect(screen.getByText('Name')).toBeTruthy();
    expect(screen.getByText('Category')).toBeTruthy();
    expect(screen.getByText('Product Code')).toBeTruthy();
    expect(screen.getByText('SKU')).toBeTruthy();
    expect(screen.getByText('Stock Quantity')).toBeTruthy();
    expect(screen.getByText('Price')).toBeTruthy();    
  })
})

