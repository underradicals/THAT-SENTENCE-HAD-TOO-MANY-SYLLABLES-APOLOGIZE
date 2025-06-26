import '@/pages/MainLayout.scss';
import { Outlet } from 'react-router';


function MainLayout() {
  return <>
    <h1>Main Layout</h1>
    <Outlet />
  </>
}

export default MainLayout;