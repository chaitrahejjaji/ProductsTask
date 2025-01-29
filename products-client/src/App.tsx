import './App.css'
import 'react-tabs/style/react-tabs.css';
import ProductContextProvider from './store/ProductContext';
import ProductDashboard from './components/ProductDashboard';

function App() {
  return (    
    <ProductContextProvider>
     <ProductDashboard/>
    </ProductContextProvider>
  )
}

export default App
