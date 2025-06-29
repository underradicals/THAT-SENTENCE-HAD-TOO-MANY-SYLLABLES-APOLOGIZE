import { Suspense, useEffect, useState } from 'react';

import '@/pages/Home/Home.scss';

async function get(func: React.Dispatch<React.SetStateAction<{ message: string }>>) {
  const response = await fetch('http://localhost:5000');

  if (!response.ok) throw new Error('Network response was not ok');
  const data = await response.json();
  console.log(data);
  func(data);
}

function Home() {
  const [data, setData] = useState<{ message: string }>({ message: '' });

  useEffect(() => {
    get(setData);
  }, []);

  return <>
    <h1>Home Page</h1>
    <Suspense fallback={<div>Loading...</div>}>
      <h3>{data.message}</h3>
    </Suspense>
  </>
}

export default Home;