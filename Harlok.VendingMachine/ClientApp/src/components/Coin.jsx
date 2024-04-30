import {memo, useEffect, useRef} from "react";

const CoinComponent = ({coinData}) => {
    const canvasRef = useRef(null);


    useEffect(() => {
        const canvas = canvasRef.current;
        const context = canvas.getContext('2d');
        const image = new Image();

        image.onload = () => {

            // const cropWidth = coinData.width;
            const cropWidth = 300;
            const cropHeight = 288;
            // const cropHeight = coinData.height;

            canvas.width = cropWidth / 4;
            canvas.height = cropHeight / 4;

            // context.clearRect(0, 0, canvas.width, canvas.height);
            context.drawImage(
                image,
                // coinData.x,
                288,
                // coinData.y,
                0,
                cropWidth,
                cropHeight,
                0,
                0,
                cropWidth / 4,
                cropHeight / 4
            );
        };

        image.src = "/img/coins/coins_high.png";
    }, [coinData]);

    return <canvas ref={canvasRef} />;
}

export const Coin = memo(CoinComponent);

//
// import {useEffect, useRef} from "react";
//
// export const Coin = ({coinData}) => {
//     const canvasRef = useRef(null);
//
//
//     useEffect(() => {
//         const canvas = canvasRef.current;
//         const context = canvas.getContext('2d');
//         const image = new Image();
//
//         image.onload = () => {
//
//             // const cropWidth = coinData.width;
//             const cropWidth = 150;
//             const cropHeight = 144;
//             // const cropHeight = coinData.height;
//
//             canvas.width = cropWidth / 4;
//             canvas.height = cropHeight / 4;
//
//             // context.clearRect(0, 0, canvas.width, canvas.height);
//             context.drawImage(
//                 image,
//                 // coinData.x,
//                 145,
//                 // coinData.y,
//                 0,
//                 cropWidth,
//                 cropHeight,
//                 0,
//                 0,
//                 cropWidth / 4,
//                 cropHeight / 4
//             );
//         };
//
//         image.src = "/img/coins/coins_high.png";
//     }, [coinData]);
//
//     return <canvas ref={canvasRef} />;
// }