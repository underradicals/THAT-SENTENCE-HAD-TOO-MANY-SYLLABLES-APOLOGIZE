import type { MainContainerProps } from "@/types";

function MainContainer({ children }: MainContainerProps) {
  return <>
    <main className='ta-main'>
      {children}
    </main>
  </>
}

export default MainContainer;
