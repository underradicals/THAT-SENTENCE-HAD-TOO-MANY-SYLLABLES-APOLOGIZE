import Home from '@/pages/Home/Home';
import MainLayout from '@/pages/MainLayout';
import { createBrowserRouter } from 'react-router';

const Router = createBrowserRouter([
  {
    path: '/',
    Component: MainLayout,
    children: [
      {
        index: true,
        Component: Home,
      }
    ],
  }

]);


export default Router;