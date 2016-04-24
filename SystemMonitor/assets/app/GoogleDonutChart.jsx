// ReSharper disable once Es6Feature
class GoogleDonutChart extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        //let divStyle = {
        //    height: this.props.height
        //}
        return (<div id={this.props.graphName}>{this.props.data.Usage}</div>);
    }

    //componentDidMount() {
    //    this.drawCharts();
    //}
    //componentDidUpdate() {
    //    this.drawCharts();
    //}

    //drawCharts() {
    //    var data = google.visualization.arrayToDataTable(this.props.data);
    //    var options = {
    //        title: 'ABC'
    //    };

    //    var chart = new google.visualization.LineChart(
    //      document.getElementById(this.props.graphName)
    //    );
    //    chart.draw(data, options);
    //}
}