import { AgGridReact } from "ag-grid-react";
import { useState } from "react";
import { AllCommunityModule, ColDef, ModuleRegistry } from 'ag-grid-community';
import { themeQuartz } from 'ag-grid-community';
import "./styles.css";
import { useProductContext } from "../store/ProductContext";
import AddProduct from "./AddProduct";
import { Product } from "../store/Product";
ModuleRegistry.registerModules([AllCommunityModule]);

export default function ProductsTable() {

  let { Products } = useProductContext();

  const [colDefs] = useState<ColDef<Product>[]>([
    { field: "name", headerClass:"tableheader"},
    { field: "category" },
    { field: "price" },
    { field: "productCode" },
    { field: "sku", headerName:"SKU" },
    { field: "stockQuantity" },
    { field: "dateAdded" }
  ]);

  const defaultColDef = {
    editable: true,
    flex: 1,
    minWidth: 100,
    filter: true,
    };

  const myTheme = themeQuartz.withParams({
    backgroundColor: 'rgb(249, 249, 249)',
    foregroundColor: 'rgb(45, 12, 23)',
    headerTextColor: '#e3e7e8',
    headerBackgroundColor: '#1b5876',
    oddRowBackgroundColor: 'rgb(0, 0, 0, 0.03)',
    headerColumnResizeHandleColor: 'rgb(126, 46, 132)',
  });
  
  return (
    < div style={{ width: "100%", height: 400 }}>
      <AddProduct></AddProduct>
      <AgGridReact data-testid="prductsGrid"
        theme={myTheme}
        rowData={Products}
        defaultColDef={defaultColDef}
        columnDefs={colDefs}  
        pagination={true}
        paginationAutoPageSize={true}      
      />
    </div>
  )
}