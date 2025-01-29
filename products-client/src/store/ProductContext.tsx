import { createContext, ReactNode, useContext, useState } from "react";
import { ProductsApi } from "../api/ProductsApi";
import { Product } from "./Product";

type ProductState = {
    Products: Product[],
    Error: string
}
type ProductContext = ProductState & {
    AddProduct: (productData: Product) => Promise<void>;
    LoadProducts: () => Promise<void>;
}

const ProductContextInstance = createContext<ProductContext | null>(null);

export function useProductContext(): ProductContext {
    const productCtx = useContext(ProductContextInstance);
    if (productCtx === null) {
        throw new Error('Context is null - that should never be the case!');
    }
    return productCtx;
}

type ProductContextProviderProps = {
    children: ReactNode
}

export default function ProductContextProvider({ children }: ProductContextProviderProps) {

    let [productState, setProductState] = useState<ProductState>({ Products: [], Error: '' });
    let context = {
        AddProduct: async (productData: Product) => {
            await ProductsApi.create(productData).then(async () => {
                let productsFromApi = await ProductsApi.getAll().catch(e => {
                    if (e.response) {
                        setProductState({ ...productState, Error: e.response.data });
                    }
                    return [];
                });
                setProductState({ Error: '', Products: productsFromApi });
            }).catch(e => {
                if (e.response) {
                    setProductState({ ...productState, Error: e.response.data });
                }
            });

        },
        LoadProducts: async () => {
            let productsFromApi = await ProductsApi.getAll().catch(e => {
                if (e.response) {
                    setProductState({ ...productState, Error: e.response.data });
                }
                return [];
            });
            setProductState({ Error: '', Products: productsFromApi });
        },
        GetProducts: (): Product[] => {
            return productState.Products;
        },
        Products: productState.Products,
        Error: productState.Error
    }

    return <ProductContextInstance.Provider value={context}>{children}</ProductContextInstance.Provider>
}