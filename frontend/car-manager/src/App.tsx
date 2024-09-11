import { Button, Flex, Table, TableColumnsType } from 'antd';
import { useEffect, useState } from "react";
import { Car } from "./models/Car.ts";
import axios from "axios";

interface DataType {
    key: React.Key,
    name: string,
    brand: string,
    bodyType: string,
    seatsCount: number,
    url?: string,
    createdAt: Date,
};

const columns: TableColumnsType<DataType> = [
    { title: 'Модель', dataIndex: 'name' },
    { title: 'Бренд', dataIndex: 'brand' },
    { title: 'Тип кузова', dataIndex: 'bodyType' },
    { title: 'Количество сидений', dataIndex: 'seatsCount' },
    { title: 'Изображение', dataIndex: 'key', render: (id: string) => <a href={`http://localhost:5206/api/cars/image/${id}`} download>Download Image</a> },
    { title: 'Ссылка', dataIndex: 'url', render: (url: string) => <a href={url} target="_blank">{url}</a> },
    { title: 'Создан', dataIndex: 'createdAt' }
];

const App = () =>  {
    const [data, setData] = useState<Car[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get<Car[]>('http://localhost:5206/api/cars', {
                    headers: {"Access-Control-Allow-Origin": "*"}
                });
                setData(response.data);
            } catch (err) {
                console.log(err);
                setError('Ошибка при загрузке данных');
            } finally {
                setLoading(false);
            }
        };

        fetchData();
    }, []);

    const dataSource = data.map<DataType>((car) => ({
        key: car.id,
        bodyType: car.bodyType.name,
        brand: car.brand.name,
        name: car.modelName,
        seatsCount: car.seatsCount,
        url: car.url,
        createdAt: car.createdAt
    }));

    return (
        <Flex gap="middle" vertical>
            <Flex align="center" gap="middle">
                <Button type="primary">Новый авто</Button>
            </Flex>
            <Table columns={columns} dataSource={dataSource} rowKey="id" />
            {loading && <div>Загрузка...</div>}
            {error && <div>Ошибка: {error}</div>}
        </Flex>
    );
};

export default App;