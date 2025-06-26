import { StrictMode } from 'react';
import '@/App.css';
import { RouterProvider } from 'react-router';
import Router from '@/routes';



function App() {
  return <StrictMode>
    <RouterProvider router={Router} />
  </StrictMode>
}

export default App
