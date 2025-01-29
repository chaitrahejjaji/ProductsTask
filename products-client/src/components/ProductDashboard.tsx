import { Tab, TabList, TabPanel, Tabs } from "react-tabs";
import ProductsChart from "./ProductsChart";
import ProductsTable from "./ProductsTable";
import { useProductContext } from "../store/ProductContext";
import { useEffect } from "react";

export default function () {
    let context = useProductContext();

    useEffect(() => {
        context.LoadProducts();
    }, [])

    return (
        <>
            {context.Error !== '' && <p style={{color:'white', background:'rgb(178, 80, 80)'}}>{context.Error}</p>}
            <Tabs style={{ width: 1300 , textAlign:"start", height:800}}>
                <TabList>
                    <Tab data-testid="gridTab">Table</Tab>
                    <Tab data-testid="chartsTab">Charts</Tab>
                </TabList>

                <TabPanel>
                    <h2>Products Table</h2>
                    <ProductsTable data-testid="productsTable"/>
                </TabPanel>
                <TabPanel>
                    <h2>Product Charts</h2>
                    <ProductsChart data-testid="productsChart"/>
                </TabPanel>
            </Tabs>
        </>
    );
}