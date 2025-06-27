interface MainContainerProps {
  children: React.ReactNode;
}

function MainContainer({ children }: MainContainerProps) {
  return <>
    <main className='ta-main'>
      {children}
    </main>
  </>
}

export default MainContainer;
