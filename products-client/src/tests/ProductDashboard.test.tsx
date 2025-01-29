
import { render, screen, } from '@testing-library/react';
import ProductContextProvider from '../store/ProductContext';
import { describe, expect, it, } from 'vitest';
import ProductDashboard from '../components/ProductDashboard';


describe('Product Dashboard', () => {
  it('Renders the tabs', () => {
    render(
      <ProductContextProvider>
        <ProductDashboard />
      </ProductContextProvider>)
    expect(screen.getByTestId('gridTab')).toBeTruthy();
    expect(screen.getByTestId('chartsTab')).toBeTruthy();
  }),
  it('Opens the products table tab', () => {
    render(
      <ProductContextProvider>
        <ProductDashboard />
      </ProductContextProvider>)
    expect(screen.getByText('Products Table')).toBeTruthy(); // Default tab is the rendered
  })
})

