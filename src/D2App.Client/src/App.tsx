import { StrictMode } from 'react';
import '@/App.css';
import { RouterProvider } from 'react-router';
import Router from '@/routes';

function isOpaque(origin: string) {
  return false;
}

export function getDomain(origin: string): string | null {
  const bk = [];
  if (isOpaque(origin)) {
    return null;
  }

  if (!origin.startsWith("https://") && !origin.startsWith("http://")) {
    throw new Error("Origin must start with 'https://' or 'http://'");
  }

  let hostPlusSubDirectories = origin.startsWith("https")
    ? origin.replace("https://", "")
    : origin.replace("http://", "");

  if (hostPlusSubDirectories.includes("/")) {
    bk.push(hostPlusSubDirectories.split("/")[0]);
  }

  if (hostPlusSubDirectories.includes("?")) {
    const value = bk.pop() as string;
    bk.push(value.split("?")[0]);
  }

  const host = bk[0] as string;
  const parts = host.split(".");
  const domain = parts.slice(-2).join(".");

  if (domain) {
    return domain;
  }

  return origin || null;
}

function App() {
  // console.log(getDomain("https://www.google.com/api/v1/values?test=1234"))
  // console.log(getDomain("https://www.google.com?test=1234"))
  // console.log(getDomain("https://www.google.com"));
  return <StrictMode>
    <RouterProvider router={Router} />
  </StrictMode>
}

export default App


