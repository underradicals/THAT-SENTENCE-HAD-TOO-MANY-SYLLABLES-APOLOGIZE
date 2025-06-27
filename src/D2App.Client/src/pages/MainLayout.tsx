import { Outlet } from 'react-router';
import '@/pages/MainLayout.scss';


function MainLayout() {
  return <>
    <h1>Main Layout</h1>
    <Outlet />
  </>
}

export default MainLayout;