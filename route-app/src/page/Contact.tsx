import { useParams } from "react-router-dom";
import Navbar from "../component/Navbar"

const Contact = () => {
    const { param } = useParams();
  return (
    <div>
        <Navbar />
          <h1>Contact </h1>
          <h2>Param: {param}</h2>
    </div>
  )
}

export default Contact