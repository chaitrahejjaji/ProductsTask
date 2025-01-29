import { useState } from "react";
import { AgCharts } from "ag-charts-react";
import { AgChartOptions } from "ag-charts-community";
import { useProductContext } from "../store/ProductContext";
import { Product } from "../store/Product";


export default function ProductsChart() {

  let { Products } = useProductContext();

  type PlottingValues = {
    name: string,
    value: number
  }

  type ProductWithPeriod = Product & {
    period: "This Week" | "This Month" | "This Year" | "Previous Years"
  }

  let [categoryChartOptions] = useState<AgChartOptions>(
    {
      title: {
        text: "Stock by product category",
      },
      data: GetProductQuantityByCategory(),
      series: [
        {
          type: "bar",
          xKey: "name",
          yKey: "value",
          yName: "Stock Quantity",
          fill: "#1b5876"
        },
      ],
    });

  function GetProductQuantityByCategory() {
    let productGroups: PlottingValues[] = [];
    var groups = Object.entries(Products.reduce((g, product) => {
      g[product.category] = g[product.category] ? g[product.category] + product.stockQuantity : product.stockQuantity;
      return g;
    }, {} as { [Key: string]: number }));
    groups.map(([key, sum]) => productGroups.push({ name: key, value: sum }));
    return productGroups;
  }

  let [periodGroupChartOptions] = useState<AgChartOptions>({
    title: {
      text: "Products by period groups",
    },
    data: getProductPeriods(),
    series: [
      {
        type: "bar",
        xKey: "name",
        yKey: "value",
        yName: "Products Added",
        fill: 'rgb(88, 39, 91)'
      },
    ],
  });

  function isDateInThisWeek(date: Date) {
    const today = new Date();
    const day = today.getDay();
    const firstDayOfTheWeek = new Date();
    const lastDayOfTheWeek = new Date();
    firstDayOfTheWeek.setHours(0, 0, 0, 0);
    lastDayOfTheWeek.setHours(0, 0, 0, 0);
    firstDayOfTheWeek.setDate(today.getDate() - day);
    lastDayOfTheWeek.setDate(firstDayOfTheWeek.getDate() + 6);
    let isThisWeek = new Date(date) >= firstDayOfTheWeek && new Date(date) <= lastDayOfTheWeek;
    return isThisWeek;
  }

  function isDateInThisMonth(date: Date) {
    const thisMonth = new Date().getMonth();
    return new Date(date).getMonth() === thisMonth && isDateInThisYear(date);
  }

  function isDateInThisYear(date: Date) {
    const thisYear = new Date().getFullYear();
    return new Date(date).getFullYear() === thisYear;
  }


  function getProductPeriods() {
    let productGroups: PlottingValues[] = [];
    let productsWithPeriods: ProductWithPeriod[] = [];
    Products.sort((a,b) => {return a.dateAdded < b.dateAdded? 1 :-1}).map((p) => {
      productsWithPeriods.push({
        ...p, period: isDateInThisWeek(p.dateAdded) ?
          "This Week" : isDateInThisMonth(p.dateAdded) ? "This Month" : isDateInThisYear(p.dateAdded)
            ? "This Year" : "Previous Years"
      })
    })
    var groups = Object.entries(productsWithPeriods.reduce((g, product) => {
      g[product.period] = g[product.period] ? g[product.period] + 1 : 1;
      return g;
    }, {} as { [Key: string]: number }));
    groups.map(([key, count]) => productGroups.push({ name: key, value: count }));
    return productGroups;
  }

  return (
    <>
      <AgCharts key="categoryChart" options={categoryChartOptions} />
      <AgCharts key="periodicalChart" options={periodGroupChartOptions} />
    </>
  );
}